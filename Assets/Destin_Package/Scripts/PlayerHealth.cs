using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public FloatVariable currentHealth;
    public FloatVariable startingHealth;
    public FloatVariable maxHealth;

    public Slider healthBar;

    public GameObject fill;
    public GameObject thingToCauseDamage;

    float regenWaitTime = 3;
    private bool regenActive;
    bool regenerate;

    int upgradeIndex = 1;

    private void Start()
    {
        maxHealth.SetValue(100);
        currentHealth.SetValue(maxHealth);
        healthBar.value = 1;
    }

    private void Update()
    {
        if (regenActive)
        {
            regenWaitTime -= Time.deltaTime;
            if (regenWaitTime <= 0)
            {
                regenActive = false;
                regenWaitTime = 3;
                regenerate = true;
            }
        }

        if (regenerate)
        {
            currentHealth.ApplyChange(10 * Time.deltaTime);
            UpdateHealthBar();
            if (currentHealth.Value >= maxHealth.Value)
            {
                regenerate = false;
                currentHealth.SetValue(maxHealth);
            }
        }
    }

    public void TakeDamage()
    {
        DamageDealer damage = thingToCauseDamage.GetComponent<DamageDealer>();

        regenerate = false;
        regenWaitTime = 3;
        regenActive = true;
        currentHealth.ApplyChange(-damage.damageAmount.Value);
    }

    public void UpdateHealthBar()
    {
        healthBar.value = currentHealth.Value / maxHealth.Value;
        if (currentHealth.Value <= 0)
        {
            fill.SetActive(false);
        }
    }

    public void UpgradeHealth()
    {
        maxHealth.SetValue(startingHealth.Value + (10 * upgradeIndex));
        currentHealth.ApplyChange(10);
        upgradeIndex++;
        UpdateHealthBar();
    }
}
