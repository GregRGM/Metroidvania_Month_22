using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public Lever _currentLever;
    public GrabbableObject _currentGrabbableObject;

    public void LeverInteract()
    {
        if(_currentLever != null)
            _currentLever.Activate();
    }

    public void GrabObject()
    {
        if(_currentGrabbableObject != null)
        _currentGrabbableObject.Grab();
    }

    public void LetGoOfObject()
    {
        if(_currentGrabbableObject != null)
        _currentGrabbableObject.LetGo();
    }
}
