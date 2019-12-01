using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponTriggerController : MonoBehaviour
{
    private Collider coll;
    private bool exit;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        coll = gameObject.GetComponent<BoxCollider>();
        exit = false;
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(exit && timer > .5f)
        {
            coll.enabled = true;
            timer = 0f;
            exit = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject.CompareTag("AI"))
        {
            coll.enabled = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (gameObject.CompareTag("AI"))
        {
            exit = true;
        }
    }

}
