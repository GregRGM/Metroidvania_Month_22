using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private GameInput _input;
    private float _canAttack = -1f;
    private float _attackRate = 1.5f;
    
    private void Start()
    {
        _input = new GameInput();
        _input.Player.Enable();
        _input.Player.BasicAttack.performed += BasicAttack_performed;
    }

    private void BasicAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(Time.time > _canAttack)
        {
            Debug.Log("Attack");
            _canAttack = Time.time + _attackRate;
        }
    }
}
