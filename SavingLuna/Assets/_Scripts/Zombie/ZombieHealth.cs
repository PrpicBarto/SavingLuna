using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] Image healthbar; // Reference to the health bar UI element
    [SerializeField] float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    private void Update()
    {
        healthbar.fillAmount = currentHealth / maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject); // Destroy the zombie when health reaches 0
        }
    }
}
