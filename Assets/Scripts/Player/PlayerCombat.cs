using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class PlayerCombat : MonoBehaviour
{
    private GameInput _input;
    private float _canAttack = -1f;
    private float _attackRate = 1.5f;
    PlayerAnimationManager _playerAnimationManager;
    private string ATTACK_ANIM = "Attack";

    [SerializeField]
    private GameObject visualEffect;

    private void Start()
    {
        _playerAnimationManager = GetComponent<PlayerAnimationManager>();
        _input = new GameInput();
        _input.Player.Enable();
        _input.Player.BasicAttack.performed += BasicAttack_performed;
    }

    private void BasicAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        if(Time.time > _canAttack)
        {
            _playerAnimationManager.ChangeAnimationState(ATTACK_ANIM);
            _canAttack = Time.time + _attackRate;
            visualEffect.SetActive(true);
            StartCoroutine(TurnOffVFX());
        }
    }

    IEnumerator TurnOffVFX()
    {
        yield return new WaitForSeconds(1);
        visualEffect.SetActive(false);
    }
}
