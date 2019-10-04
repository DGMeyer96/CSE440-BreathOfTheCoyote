using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashscript : MonoBehaviour
{

    private float timerdash;
    public float timetodash = .4f;//time dash force is applied

    public float cooldowntime = 3f;//time until can dash again
    private float timer;

    private bool candash;
    private bool dashing;

    private Rigidbody rb;
    public float dashSpeed = 20f;

    void Start()
    {
        candash = true;
        dashing = false;
        timerdash = 0f;
        timer = 0f;
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

        //if lCTRL is pressed dashing = true apply force
        //candash = false start cooldown
        if (Input.GetButtonDown("Dash") && candash)
        {
            print("test");
            candash = false;
            dashing = true;
            timer = 0f;
            timerdash = 0f;
        }

        if (dashing)//apply dash force for 1 seconds
        {
            timerdash += Time.deltaTime;
            if (timerdash < timetodash)//if timer is less than totaltime then continue applying force
            {
                float moveVertical = Input.GetAxis("Vertical");
                float moveHorizontal = Input.GetAxis("Horizontal");
                Vector3 movementd = new Vector3(moveHorizontal, 0.0f, moveVertical);
                movementd = movementd * dashSpeed * Time.deltaTime;
                movementd = transform.worldToLocalMatrix.inverse * movementd;
                rb.MovePosition(transform.position + movementd);
            }
            else if (timerdash >= timetodash)//else stop applying force
            {
                timerdash = 0f;
                dashing = false;
            }
            print(timer + "time to dash");
        }

        if (!candash)
        {
            timer += Time.deltaTime;
            if (timer >= cooldowntime)
            {
                timer = 0;
                candash = true;
            }
        }

    }
}
