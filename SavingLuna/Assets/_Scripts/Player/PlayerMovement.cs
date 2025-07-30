using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed;
  //  [SerializeField] private TMP_Text scoreText;
    

    private int score = 0;

    Vector3 moveDirection;

    private void Start()
    {
//        IncreaseScore(0);
    }

    private void FixedUpdate()
    {
        playerRigidbody.linearVelocity = Vector3.zero;
        
        if (Input.GetKey(KeyCode.A)/* && transform.position.x > -7*/)
        {
           // playerRigidbody.linearVelocity = Vector2.left * speed * Time.deltaTime;
           Move(Vector3.left);
        }

        if (Input.GetKey(KeyCode.D)/* && transform.position.x < 7*/)
        {
            //playerRigidbody.linearVelocity = Vector2.right * speed * Time.deltaTime;
            Move(Vector3.right);
        }

        moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.A))
        {
            moveDirection += -transform.right;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveDirection += transform.right;
        }
    }

    private void Move(Vector3 direction)
    {
        direction.Normalize();
        Vector3 targetVelocity = direction * speed;
        playerRigidbody.linearVelocity =
            Vector3.Lerp(playerRigidbody.linearVelocity, targetVelocity, 10 * Time.deltaTime);
    }
/*
    public void IncreaseScore(int amount)
    {
        score += amount;
        scoreText.text = score.ToString();
    }
*/
}
