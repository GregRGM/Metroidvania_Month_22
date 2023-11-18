using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    PlayerInteraction _playerInteraction;
    [SerializeField]
    private bool _canGrab = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHands"))
        {
            _canGrab = true;
            _playerInteraction = other.GetComponentInParent<PlayerInteraction>();
            _playerInteraction._currentGrabbableObject = this;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerHands"))
        {
            _canGrab = false;
            _playerInteraction._currentGrabbableObject = null;
        }
    }

    public void Grab()
    {
        transform.parent.parent = _playerInteraction.transform; // sets parent to Player object
    }
    public void LetGo()
    {
        transform.parent.parent = null;
    }

}
