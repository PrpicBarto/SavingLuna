using System;
using UnityEngine.AI;
using UnityEngine;

public class ZombieEnemyMovementScript : MonoBehaviour
{
    public Transform playerTarget;
    [SerializeField] public float movementSpeed = 5f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private float attackRange;
    [SerializeField] private float distanceToPlayer;

    [SerializeField] private bool pathCalculate = false;

    Vector3 startingPoint;
    [SerializeField] NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        startingPoint = transform.position;
    }
    private void Update()
    {
        distanceToPlayer = Vector3.Distance(navMeshAgent.transform.position, playerTarget.position);
        if(distanceToPlayer < attackRange)
        {
            navMeshAgent.isStopped = true;
            // Attack the player
            Debug.Log("Zombie is attacking the player!");
        }
        else
        {
            navMeshAgent.isStopped = false;
            if(!navMeshAgent.hasPath && pathCalculate)
            {
                navMeshAgent.destination = startingPoint;
                pathCalculate = false;
            }
            else
            {
                navMeshAgent.destination = playerTarget.position;
                pathCalculate = true;
            }
        }

        //transform.position = Vector3.MoveTowards(
        //    transform.position,
        //    playerTarget.position,
        //    movementSpeed * Time.deltaTime);
        //transform.LookAt(playerTarget.position);
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
                playerRigidbody.AddForce(-playerMovement.transform.forward * 50, ForceMode.Impulse);
                Debug.Log("Zombie pushed the player!");
        }
    }
}