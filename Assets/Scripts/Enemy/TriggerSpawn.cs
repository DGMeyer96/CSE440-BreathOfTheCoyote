using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public Transform enemyPosition;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    private int spawnCounter = 0;
    public bool firstDeath;

    private void Start()
    { 
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("AI") == null && spawnCounter == 0){

                Instantiate(enemy1, enemyPosition.position, enemyPosition.rotation);
                spawnCounter = 1;
            }

            else if (GameObject.FindGameObjectWithTag("AI") == null && spawnCounter == 1)
            {

                Instantiate(enemy2, enemyPosition.position, enemyPosition.rotation);
                spawnCounter = 2;
            }

            else if (GameObject.FindGameObjectWithTag("AI") == null && spawnCounter == 2)
            {

                Instantiate(enemy3, enemyPosition.position, enemyPosition.rotation);
                spawnCounter = 0;
            }

        }
    }
}
