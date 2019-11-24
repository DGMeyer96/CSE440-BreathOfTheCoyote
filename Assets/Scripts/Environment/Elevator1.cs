using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator1 : MonoBehaviour
{
    public GameObject[] points;
    int current = 0;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {

        if (current !=0 && transform.position != points[current].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);

        }
        if (current == 0 && transform.position != points[current].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            current = 1;
            //Debug.Log(current);
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            current = 1;
            //Debug.Log(current);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        current = 0;
        //Debug.Log(current);
    }

}
