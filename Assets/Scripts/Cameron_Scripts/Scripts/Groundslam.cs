using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Groundslam : MonoBehaviour
{
    public GameObject groundv1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameObject slamvfx = Instantiate(groundv1, transform.position, transform.rotation);

        }
            //Placeholder
            //This program isn't set yet as nothing is prepared to use it
            //If an object that has a certain attachment to it is nearby when it is pressed, then something happens
        
    }
}
