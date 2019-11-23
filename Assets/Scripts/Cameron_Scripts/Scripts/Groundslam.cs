using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundslam : MonoBehaviour
{
    public GameObject groundv1;
    private Animator grndslamAni;
    public GameObject player;
    private bool temp;
    private Rigidbody rb;
    private bool groundedcheck;
    private float cooldown;
    private float timeClip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        grndslamAni = GetComponent<Animator>();
        cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        groundedcheck = GetComponent<PlayerController>().isGrounded;
        if (cooldown > 2)
        {
            grndslamAni.SetBool("GroundSlam", true);
            if (Input.GetAxis("Groundslam") > 0)
            {
                if (!groundedcheck)

                {
                    rb.AddForce(0, -1500, 0);
                    temp = true;
                }
                else
                {
                    
                    GameObject slamvfx = Instantiate(groundv1, transform.position, transform.rotation);
                    Destroy(slamvfx, 2.0f);
               
                }
                cooldown = 0f;

            }

        }
        if (temp)
        {
            if(groundedcheck)
            {
                GameObject slamvfx = Instantiate(groundv1,transform.position, transform.rotation);
                Destroy(slamvfx, 2.0f);
                temp = false;
                grndslamAni.SetBool("GroundSlam", true);
            }
        }
        //Placeholder
        //This program isn't set yet as nothing is prepared to use it
        //If an object that has a certain attachment to it is nearby when it is pressed, then something happens

    }
}
