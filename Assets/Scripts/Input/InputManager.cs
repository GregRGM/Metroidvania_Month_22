using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
public class InputManager : MonoBehaviour
{
    public GameInput _input;
    private PlayerMovement _playerMovement;
    private PlayerCombat _playerCombat;
    private PlayerInteraction _playerInteraction;
    private MenuCursor _menuCursor;

    private int _sceneBuildIndex;
    // Start is called before the first frame update
    void Start()
    {
        _sceneBuildIndex = SceneManager.GetActiveScene().buildIndex;

        switch(_sceneBuildIndex)
        {
            case 0:
                _input = new GameInput();
                EnableUIActions(); // enable UI inputs
                break;

            case 1:
                _input = new GameInput();
                EnablePlayerActions(); // enable Player inputs
                break;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    void RegisterPlayerEvents()
    {
        _playerMovement = FindObjectOfType<PlayerMovement>();
        _playerCombat = FindObjectOfType<PlayerCombat>();
        _playerInteraction = FindObjectOfType<PlayerInteraction>();

        _input.Player.Jump.performed += Jump_performed;
        _input.Player.PullUp.performed += PullUp_performed;
        _input.Player.Stomp.performed += Stomp_performed;
        _input.Player.BasicAttack.performed += BasicAttack_performed;
        _input.Player.Grab.started += Grab_started;
        _input.Player.Grab.canceled += Grab_canceled;
        _input.Player.Interact.performed += Interact_performed;
    }
    void DeRegisterPlayerEvents()
    {
        _input.Player.Jump.performed -= Jump_performed;
        _input.Player.PullUp.performed -= PullUp_performed;
        _input.Player.Stomp.performed -= Stomp_performed;
        _input.Player.BasicAttack.performed -= BasicAttack_performed;
        _input.Player.Grab.started -= Grab_started;
        _input.Player.Grab.canceled -= Grab_canceled;
        _input.Player.Interact.performed -= Interact_performed;
    }
    void RegisterUIEvents()
    {
        _menuCursor = FindObjectOfType<MenuCursor>(true);

        _input.UI.Click.performed += Click_performed;
    }

    void DeRegisterUIEvents()
    {
        _input.UI.Click.performed -= Click_performed;
    }

    #region PLAYER SUBSCRIBERS
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
    #endregion 

    #region UI SUBSCRIBERS
    private void Click_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        _menuCursor.ClickedButton();
    }
    #endregion

    public void DisablePlayerActions()
    {
        DeRegisterPlayerEvents();
        _input.Player.Disable();
       
        Debug.Log("Player Inputs Disabled");
    }
    public void EnablePlayerActions()
    {

        _input.Player.Enable();
        RegisterPlayerEvents();
        Debug.Log("Player Inputs Enabled");
    }
    public void DisableUIActions()
    {
        DeRegisterUIEvents();
        _input.UI.Disable();       
    }
    public void EnableUIActions()
    {

        _input.UI.Enable();
        RegisterUIEvents();
        Debug.Log("UI Inputs Enabled");
    }
}
