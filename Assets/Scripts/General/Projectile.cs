using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private bool _redirected = false;
    [SerializeField]
    private float _destroyTimer;

    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime);

        if(_redirected == false)
        {
            _destroyTimer -= Time.deltaTime;
            
            if (_destroyTimer <= 0)
            {
                Destroy(this.gameObject);
            }
        }
        else if(_redirected == true)
        {
            _destroyTimer = 1;
        }

    }

    public void Redirected()
    {
        _redirected = true;
    }

    //TO DO: Check if projectile has hit anything fter being redirected. If so, destroy it. 
    ///WISHLIST = Add this to a pool instead of destroying it.
}
