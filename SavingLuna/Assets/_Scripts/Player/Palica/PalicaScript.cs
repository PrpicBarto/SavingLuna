using UnityEngine;

public class PalicaScript : MonoBehaviour
{
    float initialPalicaAngle = -60f;
    bool isFirstSwing = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (isFirstSwing)
        transform.localRotation = new Vector3(0f, initialPalicaAngle, 0f );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Attack()
    {

    }
}
