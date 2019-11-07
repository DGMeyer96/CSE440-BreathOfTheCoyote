using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;

public class FireballMovement : MonoBehaviour
{

    public Vector3 speed;
    public VisualEffect myEffect;

    public float time;
    public Rigidbody rb;
    public GameObject puzzlehold;
    public GameObject explosion;
    public static readonly string DirectionBall = "Direction";
    public static readonly string DirectionTail = "DirectionTail";


    // Start is called before the first frame update
    void Start()
    {
        
        time = 0f;
        rb = GetComponent<Rigidbody>();
        rb.velocity = (Camera.main.transform.forward * 5);
        myEffect.SetVector3(DirectionBall, -rb.velocity);
        myEffect.SetVector3(DirectionTail, -rb.velocity*2);

        Debug.Log(Camera.main.transform.forward);


        // GameObject puzzlemaster = gameObject.GetComponent<StatHolder>;

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Camera.main.transform.forward);

        //  transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
        // rigidbody.AddForce(speed);
        // rigidbody.velocity = speed;
        //rigidbody.
        // Destroy(gameObject, 2.0f);

        //    time = time + Time.deltaTime;

        //    if (time > 5)
        //    {

        //    }
    }

    private void OnCollisionEnter(Collision collision)
    {


        // Destroy(collision.gameObject);

        //Switch this over to programs on the pillars end, and when they are hit, solve is set to true.

        GameObject blowup = Instantiate(explosion, gameObject.transform.position, Quaternion.identity);
        Destroy(blowup, 3.0f);

        Destroy(gameObject);




    }
}
