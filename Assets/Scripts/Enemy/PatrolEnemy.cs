using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PatrolEnemy : EnemyBase
{
    [SerializeField]
    private GameObject _attackEffect;
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
        _attackEffect.SetActive(true);
        StartCoroutine(TurnOffVFX());
    }

    IEnumerator TurnOffVFX()
    {
        yield return new WaitForSeconds(1);
        _attackEffect.SetActive(false);
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
