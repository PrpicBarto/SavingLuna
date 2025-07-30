using System.Collections;
using UnityEngine;

public class PalicaSwing : MonoBehaviour
{
    [SerializeField] float swingSpeed = 5f; // Speed of the swing
    [SerializeField] float swingDuration = 0.2f;
    [SerializeField] float swingCooldown = 2f;

    [SerializeField] Transform swingPoint; // The point around which the swing occurs

    private bool swingLeftToRight = true; // Track direction

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
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
    }
}
