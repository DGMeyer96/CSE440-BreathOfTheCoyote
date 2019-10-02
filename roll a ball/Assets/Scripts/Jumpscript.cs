using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumpscript : MonoBehaviour
{

    private Rigidbody rb;
    public float jumpSpeed = 10f;
    private bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        isGrounded = false;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            float moveJump = Input.GetAxis("Jump");
            Vector3 jump = new Vector3(0f, moveJump, 0.0f);
            rb.AddForce(jump * jumpSpeed * Time.deltaTime, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }
    }
}