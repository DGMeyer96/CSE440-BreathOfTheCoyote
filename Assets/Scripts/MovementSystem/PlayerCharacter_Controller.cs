using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter_Controller : MonoBehaviour
{
    CharacterController characterController;

    private Animator animate;
    private Vector3 moveRotation = Vector3.zero;
    private Vector3 moveDirectionm = Vector3.zero;

    //private Vector3 movement;//controlls rotation

    private Quaternion transformrotation;

    public GameObject MindTrophy;
    public GameObject StrengthTrophy;
    public GameObject AgilityTrophy;

    public Animator CanvasAnimator;
    public Animator SaveAnimator;

    public Camera cam;

    public bool isfalling;
    public bool isOnGround;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        //Can most likely be removed, using CharacterController
        //rb = GetComponent<Rigidbody>();
        animate = GetComponent<Animator>();

        MindTrophy.SetActive(false);
        StrengthTrophy.SetActive(false);
        AgilityTrophy.SetActive(false);

        isfalling = false;
        isOnGround = false;
    }

    void Update()
    {
        float walkspeed = 0f;
        var smooth = 10;
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetAxis("Sprint") != 0)
        {
            walkspeed = speed * 1.4f;
            if (isOnGround)
            {
                animate.SetBool("Walk Forward", true);
                animate.SetBool("Running", true);
            }
        }
        else if (moveVertical != 0f || moveHorizontal != 0f)
        {
            walkspeed = speed;
            if (isOnGround)
            {
                animate.SetBool("Walk Forward", true);
                animate.SetBool("Running", false);
            }
        }
        else
        {
            if (isOnGround)
            {
                animate.SetBool("Walk Forward", false);
                animate.SetBool("Running", false);
            }
        }

        if (characterController.isGrounded)
        {

            // We are grounded, so recalculate
            // move direction directly from axes
            animate.SetBool("Jumping", false);

            //move direction is the vector 3 for controlling rotation
            moveRotation = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //movedirectionm is the move direction for controlling movement
            moveDirectionm = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            //moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                animate.SetBool("Running", false);

                moveDirectionm.y = jumpSpeed;
                animate.SetBool("Jumping", true);
            }
        }
        else
        {
            moveRotation = new Vector3(moveHorizontal / 3, 0.0f, moveVertical);
        }

        if (moveRotation.magnitude > 0)
        {
            transform.parent = null;
            transform.parent = null;
            //speed of walking
            animate.speed = 2.0f;
            Vector3 fwd = transform.position - Camera.main.transform.position;
            fwd.y = 0;
            fwd = fwd.normalized;
            if (fwd.magnitude > 0.001f)
            {
                Quaternion inputFrame = Quaternion.LookRotation(fwd, Vector3.up);
                moveRotation = inputFrame * moveRotation;
                if (moveRotation.magnitude > 0.001f)
                {
                    moveRotation *= walkspeed;
                    transformrotation = Quaternion.LookRotation(moveRotation.normalized, Vector3.up);
                    transform.rotation = Quaternion.Slerp(transform.rotation, transformrotation, Time.deltaTime * smooth);
                }
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirectionm.y -= gravity * Time.deltaTime;
        moveDirectionm.x = moveRotation.x;
        moveDirectionm.z = moveRotation.z;
        //Debug.Log(moveDirectionm.y);


        // Move the controller
        //moveDirection.y = moveDirectiong.y;
        characterController.Move(moveDirectionm * Time.deltaTime);
        if (moveVertical < 0)
        { 
            //animate.set
        }


        /*
        //Currently handled by the code provided by Unity above, will need rework for just animations
        WalkHandler();
        JumpHandler();
        */

        if (characterController.isGrounded)
        {
            isOnGround = true;
        }
        else 
        {
            isOnGround = false;
        }

        if (GetComponent<Player>().TrialOfAgility == true)
        {
            AgilityTrophy.SetActive(true);
        }

        if (GetComponent<Player>().TrialOfMind == true)
        {
            MindTrophy.SetActive(true);
        }

        if (GetComponent<Player>().TrialOfStrength == true)
        {
            StrengthTrophy.SetActive(true);
        }



    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("ground") || collision.gameObject.CompareTag("Elevator"))
        {
            //isGrounded = true;
        }

        //Used for tracking objectives and saving game
        if (collision.gameObject.name == "Agility Trophy" && GetComponent<Player>().TrialOfAgility != true)
        {
            GetComponent<Player>().TrialOfAgility = true;
            GetComponent<Player>().SaveGame();
            AgilityTrophy.SetActive(true);

            //This is causing the pause menu to break
            SaveAnimator.SetBool("Saving", true);

            //Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Mind Trophy" && GetComponent<Player>().TrialOfMind != true)
        {
            GetComponent<Player>().TrialOfMind = true;
            GetComponent<Player>().SaveGame();
            MindTrophy.SetActive(true);
            SaveAnimator.SetBool("Saving", true);

            //Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Strength Trophy" && GetComponent<Player>().TrialOfStrength != true)
        {
            GetComponent<Player>().TrialOfStrength = true;
            GetComponent<Player>().SaveGame();
            StrengthTrophy.SetActive(true);
            SaveAnimator.SetBool("Saving", true);

            //Destroy(collision.gameObject);
            //collision.gameObject.SetActive(false);
        }

        if (collision.gameObject.name == "Village" && GetComponent<Player>().TrialOfAgility == true
            && GetComponent<Player>().TrialOfStrength == true && GetComponent<Player>().TrialOfMind == true)
        {
            Debug.Log("Loading: Main Menu");
            PlayerPrefs.SetInt("LevelToLoad", 1);
            GetComponent<Player>().SaveGame();
            CanvasAnimator.SetTrigger("FadeOut");
        }
    }
    private void OnTriggerStay(Collider collision)
    {

        if (collision.gameObject.CompareTag("Elevator") && moveRotation.magnitude == 0)
        {
            //transform.parent = collision.transform;
        }
        if (moveRotation.magnitude != 0)
        {
            //transform.parent = null;

        }

    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Elevator"))
        {
            //transform.parent = null;

        }
        //transform.localScale = new Vector3(.8f, .8f, .8f);

    }
}
