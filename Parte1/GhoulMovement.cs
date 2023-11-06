using System;
using UnityEngine;

public class GhoulMovement : MonoBehaviour
{
    public float speed = 5.0f;
    private bool isJumping = false;
    private Rigidbody rb;
    private int score = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Cambie aquí para que el Ghoul no gire al colisionar con otros objectos
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
    }

    private void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = speed * Time.deltaTime * new Vector3(moveX, 0, moveZ);
        transform.Translate(move);

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.AddForce(new Vector3(0, 5.0f, 0), ForceMode.Impulse);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Bed"))
            isJumping = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Spider") && isJumping)
        {
            score += 10;
            print("Current score: " + score);
        }
    }
}
