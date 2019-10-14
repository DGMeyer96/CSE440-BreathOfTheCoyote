using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    private float speedS;
    private float old_pos;
    public bool isfalling;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        old_pos = transform.position.y;
        isfalling = false;
    }

    void FixedUpdate()
    {
        WalkHandler();

        if (old_pos == transform.position.y) //check if palyer is falling or not
        {
            isfalling = false;
        }
        else
        {
            isfalling = true;
        }
        old_pos = transform.position.y;
    }

    void WalkHandler()
    {
        if (Input.GetAxis("Sprint") > 0 && !isfalling)
        {

            speedS = speed * 2f;
        }
        else
        {
            speedS = speed;
        }
        if (isfalling)
        {
            speedS = speed * .9f;
        }

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement.magnitude > 0)
        {
            Vector3 fwd = transform.position - Camera.main.transform.position;
            fwd.y = 0;
            fwd = fwd.normalized;
            if (fwd.magnitude > 0.001f)
            {
                if (moveHorizontal != 0)
                {

                    if (movement.magnitude > 0.001f)
                    {
                        movement = movement * speedS * Time.deltaTime;
                        rb.MovePosition(transform.position + movement);
                    }
                }
                else
                {
                    Quaternion inputFrame = Quaternion.LookRotation(fwd, Vector3.up);
                    movement = inputFrame * movement;
                    if (movement.magnitude > 0.001f)
                    {
                        movement = movement * speedS * Time.deltaTime;
                        rb.MovePosition(transform.position + movement);
                        transform.rotation = Quaternion.LookRotation(movement.normalized, Vector3.up);
                    }

                }
            }
        }
    }
}