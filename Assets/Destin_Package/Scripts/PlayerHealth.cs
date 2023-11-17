using UnityEngine;
using UnityEngine.Events;
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
    [SerializeField]
    UnityEvent deathEvent;

    UIManager _uiManager;

    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();

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
            _uiManager.UpdateHealthBar();
            if (currentHealth.Value >= maxHealth.Value)
            {
                regenerate = false;
                currentHealth.SetValue(maxHealth);
            }
        }
    }

    public void TakeDamage(DamageDealer damageDealer)
    {
        regenerate = false;
        regenWaitTime = 3;
        regenActive = true;
        currentHealth.ApplyChange(-damageDealer.damageAmount.Value);

        if (currentHealth.Value <= 0)
        {
            deathEvent.Invoke();
        }

        _uiManager.UpdateHealthBar();
    }

    //public void UpdateHealthBar()
    //{
    //    Debug.Log("uPDATEhEALTH");
    //    healthBar.value = currentHealth.Value / maxHealth.Value;
    //    if (currentHealth.Value <= 0)
    //    {
    //        fill.SetActive(false);
    //    }
    //}

    public void UpgradeHealth()
    {
        maxHealth.SetValue(startingHealth.Value + (10 * upgradeIndex));
        currentHealth.ApplyChange(10);
        upgradeIndex++;
        //UpdateHealthBar();
    }

    public void Die()
    {
        Debug.Log("Died");
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer);
        }
    }
}
