using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderC : MonoBehaviour
{
    public float jumpForce = 5f;
    private bool isJumping = false;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = true;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bed"))
            isJumping = false;
    }
}
