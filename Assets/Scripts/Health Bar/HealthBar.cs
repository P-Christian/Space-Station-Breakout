using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;
    [SerializeField] private Image healthBarFill;
    [SerializeField] private Text healthText;
    public AudioSource takeDamage;
    public AudioSource playerDeath;

    private bool isDead;

    void Start()
    {
        currentHealth = 100;
        UpdateHealthBar();
    }

    public void TakeDamage(float amount)
    {
        takeDamage.Play();
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();
    }
    public void Death()
    {
        if (currentHealth <= 0 && !isDead)
        {
            isDead = true;
            playerDeath.Play();
            GetComponent<GameOver>().gameOver();
        }
    }

    private void UpdateHealthBar()
    {
        float targetFillAmount = currentHealth / maxHealth;
        healthBarFill.fillAmount = targetFillAmount;
        healthText.text = "HP: " + Mathf.Round(currentHealth).ToString();
    }
}