
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private int _sceneToLoad;
    InputManager inputManager;
    [SerializeField]
    private GameObject _gamepadCursor;
    MenuCursor _menuCursor;
    private void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        _menuCursor = FindObjectOfType<MenuCursor>(true);
    }
    public void ClickedStart()
    {
        inputManager.DisableUIActions();
        SceneManager.LoadScene(_sceneToLoad);
    }
    private void Update()
    {
        Vector2 gamepadCursorMove = inputManager._input.UI.MoveCursorGamePad.ReadValue<Vector2>();
        Vector2 mouseCursorMove = inputManager._input.UI.MoveCursorMouse.ReadValue<Vector2>();

        if(_gamepadCursor.activeInHierarchy == false)
        {
            if (gamepadCursorMove.x != 0 || gamepadCursorMove.y != 0)
            {
                _gamepadCursor.SetActive(true);
            }
        }
        else if(_gamepadCursor.activeInHierarchy == true)
        {
            if (mouseCursorMove.x != _menuCursor._currentMouseX || mouseCursorMove.y != _menuCursor._currentMouseY)
            {
                _gamepadCursor.SetActive(false);
            }
        }
       
    }
}
