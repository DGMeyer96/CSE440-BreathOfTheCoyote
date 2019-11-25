using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundslam : MonoBehaviour
{
    public GameObject groundv1;
    private Animator grndslamAni;
    public GameObject player;
    private bool temp;
    CharacterController characterController;
    private bool groundedcheck;
    private float cooldown;
    private float timeClip;
    private Vector3 moveDirection = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        grndslamAni = GetComponent<Animator>();
        cooldown = 0f;
        grndslamAni.SetBool("GroundSlam", false);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        groundedcheck = GetComponent<PlayerCharacterController>().isOnGround;
        if (cooldown > 2)
        {

            if (Input.GetAxis("Groundslam") != 0)
            {
                grndslamAni.SetBool("GroundSlam", true);
                Invoke("groundEffect", 1.1f);


            }

        }
        if (temp)
        {
            if (groundedcheck)
            {
                GameObject slamvfx = Instantiate(groundv1, transform.position, transform.rotation);
                Destroy(slamvfx, 2.0f);
                temp = false;

            }
        }
        //Placeholder
        //This program isn't set yet as nothing is prepared to use it
        //If an object that has a certain attachment to it is nearby when it is pressed, then something happens

    }

    void groundEffect()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        if (!groundedcheck)
        {
            moveDirection.y -= 100 * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime); temp = true;
        }
        else
        {

            GameObject slamvfx = Instantiate(groundv1, transform.position, transform.rotation);
            Destroy(slamvfx, 2.0f);
            grndslamAni.SetBool("GroundSlam", false);


        }
        cooldown = 0f;
    }
}
