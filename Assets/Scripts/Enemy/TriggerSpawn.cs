using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSpawn : MonoBehaviour
{
    public GameObject AI;
    public Transform aiPosition;
    private int spawnCounter = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        /*if (GameObject.FindGameObjectWithTag("AI") == null && spawnCounter < 3){
            Instantiate(AI, aiPosition.position, aiPosition.rotation);
            spawnCounter++;
        }*/

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if (GameObject.FindGameObjectWithTag("AI") == null && spawnCounter < 3)
            {
                Instantiate(AI, aiPosition.position, aiPosition.rotation);
                spawnCounter++;
            }
        }
        
    }


    void Spawn()
    {
        
    }
}
