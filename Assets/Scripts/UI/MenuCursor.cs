using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MenuCursor : MonoBehaviour
{
    InputManager _inputManager;
    MainMenu _mainMenu;
    [SerializeField]
    private float _mouseSpeed;
    
    public bool _canSelect;
    public Button _currentButton;
    public SpriteSwapper _spriteSwapper;

    public float _currentMouseX;
    public float _currentMouseY;

    void Start()
    {
        _mainMenu = FindObjectOfType<MainMenu>();
        _inputManager = FindObjectOfType<InputManager>();
    }

    private void OnEnable()
    {
        StartCoroutine(SaveMousePos());
        Cursor.visible = false;

    }
    private void OnDisable()
    {
        //change to check whether you're in a menu or not. 
        Cursor.visible = true;
    }

    IEnumerator SaveMousePos()
    {
        yield return new WaitForEndOfFrame();
        _currentMouseX = _inputManager._input.UI.MoveCursorMouse.ReadValue<Vector2>().x;
        _currentMouseY = _inputManager._input.UI.MoveCursorMouse.ReadValue<Vector2>().y;
    }

    // Update is called once per frame
    void Update()
    {
        var mousePosition = _inputManager._input.UI.MoveCursorGamePad.ReadValue<Vector2>();
        transform.Translate(new Vector2(mousePosition.x, mousePosition.y) * _mouseSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _currentButton = other.GetComponent<Button>();
        _spriteSwapper = other.GetComponent<SpriteSwapper>();

        if (_currentButton != null)
        {
            if (_spriteSwapper != null)
            {
                _canSelect = true;
                _spriteSwapper.HoverButton();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        _currentButton = null;
        _canSelect = false;
        _spriteSwapper.LeaveHoverButton();
    }

    public void ClickedButton()
    {
        if(_currentButton != null)
        {
            _currentButton.onClick.Invoke(); //calls the onclick event of the currently hovered button
        }
    }
}
