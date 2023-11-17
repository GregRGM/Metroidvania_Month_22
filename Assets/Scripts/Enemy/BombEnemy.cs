using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : EnemyBase
{
    [SerializeField]
    private bool _looping;
    [SerializeField]
    private float _countdownTimer;
    [SerializeField]
    private GameObject _explosion;

    public override void Start()
    {
        base.Start();
        enemyState = EnemyState.patrolling;
    }

    public override void Attack()
    {
        _countdownTimer -= Time.deltaTime;

        if(_countdownTimer <= 0)
        {
            Instantiate(_explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

    public override void Patrol()
    {
        base.Patrol();
        if(_looping == true)
        {
            if(transform.position == _waypoints[_waypoints.Count - 1].position)
            {
                _currentTarget = 0;
            }
        }
    }

    public override void TakeDamage(DamageDealer damageDealer)
    {

    }

    public override void Death()
    {
    }
}
