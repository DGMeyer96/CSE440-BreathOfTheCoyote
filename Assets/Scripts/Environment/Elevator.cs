using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject[] points;
    int current = 0;
    public float speed;
    bool canmove;
    float timer = 0f;
    float cooldowntime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!canmove)
        {
            timer += Time.deltaTime;
            if (timer >= cooldowntime)
            {
                timer = 0;
                canmove = true;
            }
        }


        if (transform.position != points[current].transform.position && canmove)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].transform.position, Time.deltaTime * speed);

        }
        else
        {}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            current = 1;
            Debug.Log(current);
            canmove = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        current = 0;
        Debug.Log(current);
        canmove = false;


    }

}
