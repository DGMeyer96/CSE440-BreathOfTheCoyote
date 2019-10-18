using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public TriggerPlatforms tP;
    public float speedS = 10.0f;                            // Play around with this setting to optimize the right speed for the player in the inspector.

    public float movingtime = 3.0f;                             // Adjust this to decide when the platform will turn back around.
    private float timer;
    private bool startMovingForward;                          // This will determine which direction you want the platform to moving in from the start. True for forward, False for backward.
    private bool movedone;

    private Rigidbody rb;                                         // Used to apply forces with a 2D gameobject.

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();    // Initialize the Rigidbody2D object with this gameobject's Rigidbody2D component that is attached to it in the inspector.
        movedone = false;
        startMovingForward = false;
        timer = 0;
    }

    /// <summary>
    /// Fixed Update is called once per fixed frame.
    /// Use physical behaviors (or anything involving the rigidbody) in this function.
    /// </summary>
    void FixedUpdate()
    {
        if(startMovingForward)
        {
            Vector3 pmovement = new Vector3(0.0f, 1f, 0.0f);
            pmovement = pmovement * speedS * Time.deltaTime;
            pmovement = transform.worldToLocalMatrix.inverse * pmovement;
            rb.MovePosition(transform.position + pmovement);
        }

        if (tP.startMove && !movedone)
        {
            startMovingForward = true;
            timer += Time.deltaTime;
            if (timer >= movingtime)
            {
                timer = 0;
                startMovingForward = false;
                movedone = true;
            }
        }

    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }
}
