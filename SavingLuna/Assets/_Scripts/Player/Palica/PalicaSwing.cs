using System.Collections;
using UnityEngine;

public class PalicaSwing : MonoBehaviour
{
    [SerializeField] float swingDuration = 0.2f;
    [SerializeField] float damage = 35f;

    [SerializeField] Transform swingPoint; // The point around which the swing occurs
    [SerializeField] CapsuleCollider palicaSwingCollider; // The collider that detects hits
    [SerializeField] AudioSource swingSound; // Sound to play on swing

    private bool swingLeftToRight = true; // Track direction

    private void Start()
    {
        palicaSwingCollider.enabled = false; // Disable collider initially
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        palicaSwingCollider.enabled = true; // Enable collider for the swing duration
        swingSound.PlayOneShot(swingSound.clip); // Play the swing sound
        StartCoroutine(SwingCoroutine());
        swingLeftToRight = !swingLeftToRight; // Alternate direction
    }

    IEnumerator SwingCoroutine()
    {
        float elapsedTime = 0f;
        float startAngle = swingLeftToRight ? -80f : 80f;
        float endAngle = swingLeftToRight ? 80f : -80f;
        float baseY = swingPoint.parent != null ? swingPoint.parent.eulerAngles.y : 0f;

        while (elapsedTime < swingDuration)
        {
            float angle = Mathf.Lerp(startAngle, endAngle, elapsedTime / swingDuration);
            swingPoint.eulerAngles = new Vector3(
                swingPoint.eulerAngles.x,
                baseY + angle,
                swingPoint.eulerAngles.z
            );
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        // Ensure it ends exactly at endAngle
        swingPoint.eulerAngles = new Vector3(
            swingPoint.eulerAngles.x,
            baseY + endAngle,
            swingPoint.eulerAngles.z
        );
        palicaSwingCollider.enabled = false; // Disable collider after the swing
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out ZombieHealth zombieHealth))
        {
            zombieHealth.TakeDamage(damage);
            Debug.Log("Zombie hit by a swing!");
        }
    }
}
