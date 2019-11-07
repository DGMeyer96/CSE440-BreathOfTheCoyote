﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Animator animate;

    private Player player;

    public float speed = 20f;
    public float jumpSpeed = 50f;
    public float dashSpeed = 20f;

    private Quaternion transformrotation;
    private Rigidbody rb;

    private float speedS;

    private float timerdash;
    public float timetodash = .4f;//time dash force is applied

    public float cooldowntime = 3f;//time until can dash again
    private float timer;

    private bool candash;
    public bool dashing;
    public bool isfalling;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();
        player = GetComponent<Player>();

        isfalling = false;
        isGrounded = false;

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
        JumpHandler();
    }

    void WalkHandler()
    {
        var smooth = 10;
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Sprint") > 0 && isGrounded)
        {
            speedS = speed * 2f;
            animate.speed = 1.4f;
        }
        else
        {
            speedS = speed;
        }
        if (isGrounded)
        {
            //speedS = speed * .9f;
            //moveHorizontal = 0;
        }
        if (moveVertical < 0)
        {
            speedS = .9f;
            animate.speed = 1f;

        }

        Vector3 movement;
        if (isGrounded)//restricts movement on the x axis if the pla,yer is jumping
        {
            movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        }
        else 
        {
            movement = new Vector3(moveHorizontal/3, 0.0f, moveVertical);
        }
        if (movement.magnitude == 0)
        {
            //if idle, the animation for idle plays
            //animate.ResetTrigger("isWalking");
            //animate.SetTrigger("isNotWalking");

            animate.SetBool("Walk Forward", false);

            //speed of the idle animation
            animate.speed = 1.2f;
        }
        if (movement.magnitude > 0)
        {
            //when moving, the animation for walking plays
            //animate.ResetTrigger("isNotWalking");
            //animate.SetTrigger("isWalking");
            animate.SetBool("Walk Forward", true);

            //speed of walking
            animate.speed = 2.0f;

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
    private void JumpHandler()
    {
        //Debug.Log(isGrounded);
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

        if (collision.gameObject.CompareTag("Objective"))
        {
            Debug.Log("[COLLIDER] Objective Found: " + collision.gameObject.name);

            switch (collision.gameObject.name)
            {
                case "LeftVillage":
                    player.LeftVillage = true;
                    player.health--;
                    SetPlayerHealth();
                    SavePlayer();
                    break;
                case "TrialOfStrength":
                    player.TrialOfStrength = true;
                    SavePlayer();
                    break;
                case "TrialOfMind":
                    player.TrialOfMind = true;
                    SavePlayer();
                    break;
                case "TrialOfAgility":
                    player.TrialOfAgility = true;
                    SavePlayer();
                    break;
                default:
                    break;
            }
        }


    }

    void SavePlayer()
    {
        player.playerPosition[0] = this.transform.position.x;
        player.playerPosition[1] = this.transform.position.y;
        player.playerPosition[2] = this.transform.position.z;

        player.playerRotation[0] = this.transform.rotation.x;
        player.playerRotation[1] = this.transform.rotation.y;
        player.playerRotation[2] = this.transform.rotation.z;

        player.SaveGame();
    }

    public void LoadPlayer()
    {
        transform.position = player.playerPosition;
        transform.rotation = player.playerRotation;
    }

    public void SetPlayerHealth()
    {
        GameObject.Find("Health_Slider").GetComponent<Slider>().value = player.health;
    }
}
