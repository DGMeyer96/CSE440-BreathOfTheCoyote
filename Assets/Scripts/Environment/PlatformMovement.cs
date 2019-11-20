using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject[] points;
    int current = 0;
    public float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position != points[current].transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);
        }

        if (transform.position == points[current].transform.position && current == 1) 
        {
            current = 0;
        }
        if (transform.position == points[current].transform.position && current == 0)
        {
            current = 1;
        }

    }
}
