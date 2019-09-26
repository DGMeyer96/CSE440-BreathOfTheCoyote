using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    float speedS;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        WalkHandler();
    }

    void WalkHandler()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedS = speed * 2f;
        }
        else
        {
            speedS = speed;
        }

        //two different ways to move cahracter  one uses force another uses transform
        //this code has no delay but continues to apply force even after key is released
        //recomend speed 1000
        //this code has a button delay  dont know why.  
        //recomend speed set to 10

        /*
                Vector3 movementd = new Vector3(moveHorizontal, 0.0f, moveVertical);
                movementd = movementd * dashSpeed * Time.deltaTime;
                movementd = transform.worldToLocalMatrix.inverse * movementd;
                rb.AddForce(transform.position + movementd);
         */
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement.normalized * speedS * Time.deltaTime;
        movement = transform.worldToLocalMatrix.inverse * movement;
        rb.MovePosition(transform.position + movement);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}