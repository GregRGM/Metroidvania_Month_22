using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    private void Start()
    {
        Destroy(this.gameObject, 3.0f); // change this to a pool later.
    }
    void Update()
    {
        transform.Translate(new Vector3(0, 0, 1) * _speed * Time.deltaTime);
    }

}
