using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscript : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpSpeed = 50f;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveJump = Input.GetAxis("Jump");
        if (isGrounded && moveJump > 0)
        {
            Vector3 jump = new Vector3(0f, moveJump, 0.0f);
            rb.AddForce(jump * jumpSpeed * Time.deltaTime, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}