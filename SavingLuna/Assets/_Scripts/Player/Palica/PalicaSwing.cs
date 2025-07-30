using System.Collections;
using UnityEngine;

public class PalicaSwing : MonoBehaviour
{
    [SerializeField] float swingSpeed = 5f; // Speed of the swing
    [SerializeField] float SwingAngle = 180f;
    [SerializeField] float swingDuration = 0.2f;
    [SerializeField] float swingCooldown = 2f;

    [SerializeField] bool isFirstSwing;

    [SerializeField] Transform swingPoint; // The point around which the swing occurs

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        swingPoint.Rotate(0, SwingAngle, 0);
        StartCoroutine(SwingCoroutine());
        SwingAngle = -SwingAngle; // Reverse the swing angle for the next attack
    }

    IEnumerator SwingCoroutine()
    {
        float elapsedTime = 0f;
        float initialAngle = swingPoint.eulerAngles.y;
        if(swingCooldown > 0f)
        {
            while (elapsedTime < swingDuration)
            {
                float angle = Mathf.Lerp(initialAngle, initialAngle + SwingAngle, elapsedTime / swingDuration);
                swingPoint.eulerAngles = new Vector3(swingPoint.eulerAngles.x, angle, swingPoint.eulerAngles.z);
                elapsedTime += Time.deltaTime;
                yield return null;
            }
            yield return new WaitForSeconds(swingCooldown);
        }
        // Reset the angle after the swing
        swingPoint.eulerAngles = new Vector3(swingPoint.eulerAngles.x, initialAngle - SwingAngle, swingPoint.eulerAngles.z);
    }
}
