using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 10f;
    public float jumpSpeed = 200f;
    private Rigidbody rb;
    private Collider coll;
    bool pressedJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
    }

    void FixedUpdate()
    {
        WalkHandler();
        JumpHandler();
    }

    void WalkHandler()
    {
        //below code is using rigidbody force
        //does not work players axis of rotation

        /*
        rb.velocity = new Vector3(0, rb.velocity.y, 0);
        float distance = speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        */

        //berlow code uses rigidbody move position
        //works along players axis of rotation
        float speedS;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedS = speed * 2f;
        }
        else
        {
            speedS = speed;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(h, 0f, v);
        movement = movement.normalized * speedS * Time.deltaTime;
        movement = transform.worldToLocalMatrix.inverse * movement;
        rb.MovePosition(transform.position + movement);
    }

    void JumpHandler()
    {
        float moveJump = Input.GetAxis("Jump");
        bool isGrounded = CheckGrounded();
        if (moveJump > 0f)
        {
            if (!pressedJump && isGrounded)
            {
                pressedJump = true;
                Vector3 jump = new Vector3(0f, moveJump, 0.0f);
                rb.AddForce(jump.normalized * jumpSpeed);
            }
        }
        else
        {
            pressedJump = false;
        }
    }

    bool CheckGrounded()
    {
        float sizeX = coll.bounds.size.x;
        float sizeZ = coll.bounds.size.z;
        float sizeY = coll.bounds.size.y;

        // Position of the 4 bottom corners of the game object
        // We add 0.01 in Y so that there is some distance between the point and the floor
        Vector3 corner1 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, sizeZ / 2);
        Vector3 corner3 = transform.position + new Vector3(sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX / 2, -sizeY / 2 + 0.01f, -sizeZ / 2);

        // Send a short ray down the cube on all 4 corners to detect ground
        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);

        // If any corner is grounded, the object is grounded
        return (grounded1 || grounded2 || grounded3 || grounded4);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}