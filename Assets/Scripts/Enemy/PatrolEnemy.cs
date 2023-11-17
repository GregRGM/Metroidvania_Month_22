using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolEnemy : EnemyBase
{
    public override void Start()
    {
        base.Start();
        enemyState = EnemyState.patrolling;
    }

    public override void Attack()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        transform.LookAt(_player.transform.position);

        if(distanceToPlayer < 3.0f)
        {
            SwingWeapon();
        }

    }

    void SwingWeapon()
    {
        //swing weapon or something
    }

    public override void TakeDamage(DamageDealer damageDealer)
    {
        _health -= damageDealer.damageAmount.Value;
        if(_health <= 0)
        {
            Death();
        }
       
    }

    public override void Death()
    {
        Destroy(this.gameObject);
    }
}
