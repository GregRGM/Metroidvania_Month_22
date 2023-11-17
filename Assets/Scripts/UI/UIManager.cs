using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Player UI")]
    [SerializeField]
    private Slider healthBar;
    [SerializeField]
    private FloatVariable currentHealth;
    [SerializeField]
    private FloatVariable maxHealth;

    public void UpdateHealthBar()
    {
        healthBar.value = currentHealth.Value / maxHealth.Value;
    }
}
