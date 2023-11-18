using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    //MOVEMENT
    [SerializeField]
    private List<Transform> _waypoints;
    [SerializeField]
    private int _currentTarget;
    [SerializeField]
    private bool _switching = false;
    [SerializeField]
    private float _speed;

    //CONDITIONS
    [SerializeField]
    private bool _activated = false;// flipped when associated lever is pulled. 

    public void ActivatePlatform()
    {
        _activated = true;
    }

    void FixedUpdate()
    {
        if(_activated == false) return;
        Movement();
    }

    public void Movement()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _waypoints[_currentTarget].transform.position);

        if (distanceToTarget <= 0)
        {
            if (_switching == false) // if you're moving up in the list 
            {
                if (_currentTarget < _waypoints.Count - 1) //if you're not at the end of the list
                {
                    _currentTarget++; // continue upward
                }
                else
                {
                    _switching = true;
                    _currentTarget--;
                }
            }
            else if (_switching == true) // if you're moving down the list 
            {
                if (_currentTarget > 0)
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
    }
}
