﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GroundslamDamage : MonoBehaviour
{

    public bool goddamnitihavetoaddanotherbool;
    // Start is called before the first frame update
    void Start()
    {
        goddamnitihavetoaddanotherbool = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider collision)
    {
        
        if (collision.gameObject.GetComponent<EnemyHealth>() != null && GameObject.Find("GroundSlam(Clone)") != null && goddamnitihavetoaddanotherbool == true)
        {
            Debug.Log("Collision is" + collision);

            collision.gameObject.GetComponent<EnemyHealth>().currentHealth = (collision.gameObject.GetComponent<EnemyHealth>().currentHealth - collision.gameObject.GetComponent<EnemyHealth>().damageTaken);
            Debug.Log("Health is: " + collision.gameObject.GetComponent<EnemyHealth>().currentHealth);
            collision.gameObject.GetComponent<Rigidbody>().velocity = (collision.gameObject.transform.forward * -200f);
            goddamnitihavetoaddanotherbool = false;
        }
        else if(GameObject.Find("GroundSlam(Clone)") == null && goddamnitihavetoaddanotherbool == false)
        {
            goddamnitihavetoaddanotherbool = true;
        }
        
    }
}
