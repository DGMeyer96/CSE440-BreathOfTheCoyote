using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject AI;
    public Transform aiPosition;
    public GameObject Enemy2;
    public GameObject FinalBoss;
    private int spawnCounter = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("AI") == null && spawnCounter == 0)
            {
                Instantiate(AI, aiPosition.position, aiPosition.rotation);
                spawnCounter++;
            }

            else if(GameObject.FindGameObjectWithTag("AI") == null && spawnCounter == 1)
            {
                Instantiate(Enemy2, aiPosition.position, aiPosition.rotation);
                spawnCounter++;
            }

            else if(GameObject.FindGameObjectWithTag("AI") == null && spawnCounter == 2)
            {
                Instantiate(FinalBoss, aiPosition.position, aiPosition.rotation);
                spawnCounter++;
            }
        }
        
    }


    void Spawn()
    {
        
    }
}
