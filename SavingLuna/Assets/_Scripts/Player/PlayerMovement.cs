using System;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] public bool playerHasCat;

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime -1, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, rotationSpeed * Time.deltaTime + 1, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += -transform.forward * speed * Time.deltaTime;
        }
    }
}