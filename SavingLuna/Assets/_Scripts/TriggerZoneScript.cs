using UnityEngine;

public class TriggerZoneScript : MonoBehaviour
{
    public bool playerInZone { get; private set; } = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerInZone = true;
            Debug.Log("Player entered zone!");
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerInZone = false;
            Debug.Log("Player exited zone!");
        }
    }
}
