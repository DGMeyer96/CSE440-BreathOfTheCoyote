using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;


public class ExperimentVFX : MonoBehaviour
{
    //Public Data
    public VisualEffect myEffect;
    public GameObject player;

    //These pull the directions I can change from the vfx
    public static readonly string DirectionBall = "Direction";
    public static readonly string DirectionTail = "DirectionTail";

    //Private stuff player location and vector for direction
    private Vector3 location;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Perhaps attach to movement and use velocity?
        location = (player.transform.position);
        Debug.Log(location);
        myEffect.SetVector3(DirectionBall, location);

    }
}
