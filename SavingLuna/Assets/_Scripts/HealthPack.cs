using UnityEngine;

public class HealthPack : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.Heal(50f); // Heal the player by 50 health points
            Destroy(gameObject); // Destroy the health pack after use
        }
    }
}
