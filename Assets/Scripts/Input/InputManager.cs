using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public GameInput _input;
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private PlayerInteraction _playerInteraction;
    // Start is called before the first frame update
    void Start()
    {
        _input = new GameInput();
        _input.Player.Enable();
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCombat = FindObjectOfType<PlayerCombat>();  
        _playerInteraction = FindObjectOfType<PlayerInteraction>();

        RegisterEvents();
    }

    void RegisterEvents()
    {
        _input.Player.Jump.performed += Jump_performed;
        _input.Player.PullUp.performed += PullUp_performed;
        _input.Player.Stomp.performed += Stomp_performed;
        _input.Player.BasicAttack.performed += BasicAttack_performed;
        _input.Player.Grab.started += Grab_started;
        _input.Player.Grab.canceled += Grab_canceled;
        _input.Player.Interact.performed += Interact_performed;
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerInteraction.LeverInteract();
    }

    private void Grab_canceled(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerInteraction.LetGoOfObject();
        _playerMovement._canJump = true; // reenable jump when let go
    }

    private void Grab_started(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerInteraction.GrabObject();
        _playerMovement._canJump = false; // disable jump while holding an object
    }

    private void BasicAttack_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerCombat.BasicAttack();
    }

    private void Stomp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerMovement.Stomp();
    }

    private void PullUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerMovement.StandUp();
    }

    private void Jump_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _playerMovement.Jump();
    }
}
