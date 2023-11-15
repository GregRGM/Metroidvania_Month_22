using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : MonoBehaviour
{
    protected enum EnemyState
    {
        patrolling, 
        attacking,
        death
    }
    protected EnemyState enemyState;

    [SerializeField]
    protected float _speed;
    [SerializeField] 
    protected float _health;
    [SerializeField]
    protected List<Transform> _waypoints;

    protected GameObject _player;
    private bool _switching = false;

    public virtual void Start()
    {
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        switch(enemyState)
        {
            case EnemyState.patrolling:
                Patrol();
                break;
            case EnemyState.attacking:
                Attack();
                break;
            case EnemyState.death:
                break;
        }
    }

    public virtual void Patrol() //modularize this to not hard code waypoint element 
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if ((distanceToPlayer > 1))
        {
            if(transform.position == _waypoints[0].position)
            {
                _switching = false;
            }
            else if (transform.position == _waypoints[1].position)
            {
                _switching = true;
            }

            if(_switching == false)
            {
                transform.position = Vector3.MoveTowards(transform.position, _waypoints[1].position, _speed * Time.deltaTime);
                transform.LookAt(_waypoints[1].position);
            }
            else if(_switching == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, _waypoints[0].position, _speed * Time.deltaTime);
                transform.LookAt(_waypoints[0].position);
            }
        }
        else if(distanceToPlayer < 1)
        {
            enemyState = EnemyState.attacking;  
        }
    }

    public abstract void Attack();
}
