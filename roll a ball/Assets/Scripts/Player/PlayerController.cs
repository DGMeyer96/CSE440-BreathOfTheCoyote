using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody rb;
    private float speedS;

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
        if (Input.GetAxis("Sprint") > 0)
        {

            speedS = speed * 2f;
        }
        else
        {
            speedS = speed;
        }

        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        movement = movement * speedS * Time.deltaTime;
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