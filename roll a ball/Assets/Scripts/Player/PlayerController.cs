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
        Debug.Log(isfalling);
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