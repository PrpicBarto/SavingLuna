using UnityEngine.AI;
using UnityEngine;

public class ZombieEnemyMovementScript : MonoBehaviour
{
    public Transform playerTarget;
    [SerializeField] public float movementSpeed = 2f;
    [SerializeField] private float damage = 20f;
    [SerializeField] private float attackRange = 7.5f;
    [SerializeField] private float distanceToPlayer;

    [SerializeField] private bool pathCalculate = false;

    Vector3 startingPoint;
    [SerializeField] NavMeshAgent navMeshAgent;

    public TriggerZoneScript myZone;

    private void Awake()
    {
        playerTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        transform.position = Vector3.MoveTowards(
            transform.position,
            playerTarget.position,
            movementSpeed* Time.deltaTime);
        transform.LookAt(playerTarget.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(damage);
        }
        if (other.TryGetComponent(out PlayerMovement playerMovement))
        {
            Rigidbody playerRigidbody = other.GetComponent<Rigidbody>();
            playerRigidbody.AddForce(-playerMovement.transform.forward * 50, ForceMode.Impulse);
        }
    }

}