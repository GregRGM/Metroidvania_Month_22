// ----------------------------------------------------------------------------
// Unite 2017 - Game Architecture with Scriptable Objects
// 
// Author: Ryan Hipple
// Date:   10/04/17
// ----------------------------------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

public class AbilitySlot : MonoBehaviour
{
    public AbilitySlotRuntimeSet RuntimeSet;
    public Ability abiltity;

    public Sprite selected;
    public Sprite deselected;

    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void OnEnable()
    {
       RuntimeSet.Add(this);
    }

    private void OnDisable()
    {
        RuntimeSet.Remove(this);
    }

    public void BecomeSelected()
    {
        image.sprite = selected;
    }
    public void BecomeDeselected()
    {
        image.sprite = deselected;
    }
}