using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlamPuzzle1 : MonoBehaviour
{

    public GameObject lit;

    void Start()
    {
        
    }
    void Update()
    {

    }
    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("runs");
        if (GameObject.Find("GroundSlam") != null)
      //  if (collision.gameObject.GetComponent<Groundslammer>() != null)
        {
            Debug.Log("It gets here");
            gameObject.GetComponentInParent<StatHolder>().solve1 = true;
            GameObject floom = Instantiate(lit, transform.position, Quaternion.identity);
        }
    }
}
