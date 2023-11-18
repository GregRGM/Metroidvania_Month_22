using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    PlayerInteraction _playerInteraction;

    [SerializeField]
    private bool _canActivate = false;

    [SerializeField]
    private MovingPlatform _platform; // assign in inspector
    [SerializeField]
    Animator _anim;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _playerInteraction = other.GetComponent<PlayerInteraction>();
            _playerInteraction._currentLever = this;
            _canActivate = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _playerInteraction._currentLever = null;
            _canActivate = false;

        }
    }

    public void Activate()
    {
        _platform.ActivatePlatform();
        _anim.Play("Activate");
    }
}
