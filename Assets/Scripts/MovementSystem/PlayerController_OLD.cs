using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController_OLD : MonoBehaviour
{
    public float speed = 0.1f;
    //public float playerHealth;
    
    private float speedS;
    private Rigidbody rb;
    private Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
    }

    void FixedUpdate()
    {
        WalkHandler();
    }

    void WalkHandler()
    {
        //Need to avoid KeyCode
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

        //Normalizing adds odd input delay
        //movement = movement.normalized * speedS * Time.deltaTime;

        //Used to make sure object moves with relation to camera rotation
        movement = transform.worldToLocalMatrix.inverse * movement;

        //Added Time.deltaTime to smooth out the movement
        //rb.AddForce(movement * speedS);
        rb.MovePosition(transform.position + (movement * speedS));
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
        {
            Debug.Log("[COLLIDER] Objective Found: " + other.gameObject.name);

            switch (other.gameObject.name)
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