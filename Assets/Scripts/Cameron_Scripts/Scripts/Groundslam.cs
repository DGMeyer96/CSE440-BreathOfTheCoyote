using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundslam : MonoBehaviour
{
    public GameObject groundv1;
    public GameObject player;
    private bool temp;
    private Rigidbody rb;
    private bool groundedcheck;
    private float cooldown;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cooldown = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        groundedcheck = GetComponent<PlayerController>().isGrounded;
        if (cooldown > 2)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                if (!groundedcheck)

                {
                    rb.AddForce(0, -1000, 0);
                    temp = true;
                }
                else
                {
                    GameObject slamvfx = Instantiate(groundv1, transform.position, transform.rotation);
                }
                cooldown = 0f;

            }

        }
        if (temp)
        {
            if(groundedcheck)
            {
                GameObject slamvfx = Instantiate(groundv1, transform.position, transform.rotation);
                temp = false;
            }
        }
        //Placeholder
        //This program isn't set yet as nothing is prepared to use it
        //If an object that has a certain attachment to it is nearby when it is pressed, then something happens

    }
}
