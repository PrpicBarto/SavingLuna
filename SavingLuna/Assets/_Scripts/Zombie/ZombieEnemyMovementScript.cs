using System;
using UnityEngine;

public class ZombieEnemyMovementScript : MonoBehaviour
{
    public Transform playerTarget;
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] private float damage = 20f;

    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            playerTarget.position,
            movementSpeed * Time.deltaTime);
        transform.LookAt(playerTarget.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Zombie attacked the player!");
        }
        if(other.TryGetComponent(out PlayerMovement playerMovement))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
                playerRigidbody.AddForce(-playerMovement.transform.forward * 100, ForceMode.Impulse);
                Debug.Log("Zombie pushed the player!");
        }
    }
}