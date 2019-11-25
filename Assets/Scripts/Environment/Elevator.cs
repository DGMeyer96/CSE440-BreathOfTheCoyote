using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject[] points;
    public int current = 0;
    public float speed;
    public ElevatorCheckpoint Chp;
    public bool colliding;

    // Update is called once per frame
    void Update()
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
            colliding = true;
            if (Chp.touched)
            {
                current = 2;
            }
            else
                current = 1;
        }
        else 
        {
            colliding = false;
        }
        Debug.Log("hit");
    }

    private void OnTriggerExit(Collider collision)
    {
        current = 0;
        Debug.Log(current);
    }

}
