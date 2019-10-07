using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController_OLD : MonoBehaviour
{
    [Header("Keyboard Input: ")]
    public KeyCode moveLeft = KeyCode.A;
    public KeyCode moveRight = KeyCode.D;
    public KeyCode moveForward = KeyCode.W;
    public KeyCode moveBackward = KeyCode.S;

    [Header("Horizontal Speed Settings: ")]
    public float speed = 5.0f;
    public float maxSpeed = 10.0f;

    private Rigidbody rb;
    private Player player;
    private string objectiveName;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();

        //player.playDate = DateTime.Now.ToString();

        //For testing only!
        //player.saveName = "SaveTest.sav";

        //player.NewGame();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        //player.position[0] = this.transform.position.x;
        //player.position[1] = this.transform.position.y;
        //player.position[2] = this.transform.position.z;

        //player.playTime = Time.timeSinceLevelLoad;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Objective"))
        {
            Debug.Log("[COLLIDER] Objective Found: " + other.gameObject.name);

            switch(other.gameObject.name)
            {
                case "LeftVillage":
                    player.LeftVillage = true;
                    SaveGame();
                    break;
                case "TrialOfStrength":
                    player.TrialOfStrength = true;
                    SaveGame();
                    break;
                case "TrialOfMind":
                    player.TrialOfMind = true;
                    SaveGame();
                    break;
                case "TrialOfAgility":
                    player.TrialOfAgility = true;
                    SaveGame();
                    break;
                default:
                    break;
            }
        }
    }

    void SaveGame()
    {
        player.SaveGame();
    }
}
