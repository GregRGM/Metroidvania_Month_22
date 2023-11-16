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
    [SerializeField]
    protected EnemyState enemyState;

    [SerializeField]
    protected float _speed;
    [SerializeField] 
    protected float _health;
    [SerializeField]
    protected List<Transform> _waypoints;
    [SerializeField]
    protected int _currentTarget;

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

    public virtual void Patrol()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        float distanceToTarget = Vector3.Distance(transform.position, _waypoints[_currentTarget].transform.position);

        if(distanceToPlayer > 4)
        {
            if(distanceToTarget <= 0) // if you've made it to the current target 
            {
                if(_switching == false) // if you're moving up in the list 
                {
                    if(_currentTarget < _waypoints.Count - 1) //if you're not at the end of the list
                    {
                        _currentTarget++; // continue upward
                    }
                    else
                    {
                        _switching = true;
                        _currentTarget--;
                    }
                }
                else if(_switching == true) // if you're moving down the list 
                {
                    if(_currentTarget > 0)
                    {
                        _currentTarget--; // continue downward
                    }
                    else
                    {
                        _switching = false;
                        _currentTarget++;
                    }
                }
            }

            if (_switching == false) // if moving up incrementally through waypoints
            {
                transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentTarget].position, _speed * Time.deltaTime);
            }
            else if (_switching == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, _waypoints[_currentTarget].position, _speed * Time.deltaTime);
            }

            transform.LookAt(_waypoints[_currentTarget].position);
        }

        else if (distanceToPlayer < 4)
        {
            enemyState = EnemyState.attacking;
        }
    }

    public abstract void Attack();
}
