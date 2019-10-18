using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animate;
    public float speed = 20f;
    private Rigidbody rb;
    private float speedS;
    private float old_pos;
    public bool isfalling;
    private Quaternion transformrotation;

    private float timerdash;
    public float timetodash = .4f;//time dash force is applied

    public float cooldowntime = 3f;//time until can dash again
    private float timer;

    private bool candash;
    public bool dashing;

    public float dashSpeed = 20f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
        old_pos = transform.position.y;
        isfalling = false;

        candash = true;
        dashing = false;
        timerdash = 0f;
        timer = 0f;
        animate.SetTrigger("isNotWalking");
    }

    void FixedUpdate()
    {
        
        WalkHandler();

        DashHandler();

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
        
        var smooth = 10;

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
        
        if(movement.magnitude == 0)
        {
            animate.ResetTrigger("isWalking");
            animate.SetTrigger("isNotWalking");
        }
        if (movement.magnitude > 0)
        {
            animate.ResetTrigger("isNotWalking");
            animate.SetTrigger("isWalking");

            Vector3 fwd = transform.position - Camera.main.transform.position;
           
            fwd.y = 0;
            fwd = fwd.normalized;
            if (fwd.magnitude > 0.001f)
            {
                



                Quaternion inputFrame = Quaternion.LookRotation(fwd, Vector3.up);
                movement = inputFrame * movement;
                if (movement.magnitude > 0.001f)
                {
                    movement = movement * speedS * Time.deltaTime;
                    rb.MovePosition(transform.position + movement);
                    transformrotation = Quaternion.LookRotation(movement.normalized, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, transformrotation, Time.deltaTime * smooth);
                    
                    
                }


            }
           
        }
        

    }
    private void DashHandler()
    {
        //if lCTRL is pressed dashing = true apply force
        //candash = false start cooldown
        if (Input.GetButtonDown("Dash") && candash)
        {
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
