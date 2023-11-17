using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator _anim;
    private string _currentState;

    void Start()
    {
        _anim = GetComponentInChildren<Animator>();
    }

    public void ChangeAnimationState(string newState)
    {
        if (_currentState == newState) { return; }
        _anim.Play(newState);
        _currentState = newState;
    }
}
