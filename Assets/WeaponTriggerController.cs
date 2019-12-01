using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTriggerController : MonoBehaviour
{
    private Collider coll;
    private bool collided;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<BoxCollider>();
        collided = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(collided && timer > .5f)
        {
            coll.enabled = true;
            timer = 0f;
            collided = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("AI"))
        {
            coll.enabled = false;
        }
    }


}
