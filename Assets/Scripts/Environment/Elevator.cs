﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject[] points;
    int current = 0;
    public float speed;
    public ElevatorCheckpoint Chp;

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

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Chp.touched)
            {
                current = 2;
            }
            else
                current = 1;
            Debug.Log(current);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        current = 0;
        Debug.Log(current);
    }

}
