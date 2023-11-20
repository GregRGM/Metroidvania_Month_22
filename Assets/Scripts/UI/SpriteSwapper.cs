using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteSwapper : MonoBehaviour
{
    [SerializeField]
    private Image _buttonImage;

    [SerializeField]
    private Sprite[] _sprites;

    private void Start()
    {
        _buttonImage.sprite = _sprites[0];
    }

    public void HoverButton()
    {
        _buttonImage.sprite = _sprites[1];
    }
    public void LeaveHoverButton()
    {
        _buttonImage.sprite = _sprites[0];
    }
}
