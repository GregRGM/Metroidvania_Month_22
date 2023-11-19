using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedirectProjectile : MonoBehaviour
{
    [SerializeField]
    private GameObject _exitPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Projectile"))
        {
            Projectile projectile = other.GetComponent<Projectile>();
            if(projectile != null) 
            {
                other.transform.forward = _exitPoint.transform.forward;
                other.transform.position = _exitPoint.transform.position;
                projectile.Redirected();
            }

        }
    }
}
