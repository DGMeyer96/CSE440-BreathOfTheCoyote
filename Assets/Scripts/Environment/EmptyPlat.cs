using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPlat : MonoBehaviour
{
    public GameObject player;
    public GameObject elevator;
    private bool trigger;
    private Vector3 Platmov;
    private bool moving;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        trigger = player.GetComponent<PlayerCharacterController>().plat;

        if (trigger)
        {
            player.transform.SetParent(gameObject.transform);
        }
        else
        {
            player.transform.SetParent(null);
        }




    }
}
