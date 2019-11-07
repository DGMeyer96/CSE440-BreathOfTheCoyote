using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorCheckpoint : MonoBehaviour
{
    public bool touched;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            touched = true;
        }
    }
}
