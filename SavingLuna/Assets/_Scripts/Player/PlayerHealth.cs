using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] Image healthbar;
    [SerializeField] private float maxHealth = 200f;
    [SerializeField] private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        healthbar.fillAmount = currentHealth / maxHealth;
    }
}
