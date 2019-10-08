using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{

    public Vector3 speed;
    public float time;
    public Rigidbody rigidbody;
    public GameObject puzzlehold;
    // Start is called before the first frame update
    void Start()
    {
        
        time = 0f;
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = (Camera.main.transform.forward * 5);

       // GameObject puzzlemaster = gameObject.GetComponent<StatHolder>;
        
    }

    // Update is called once per frame
    void Update()
    {
      //  transform.position += transform.TransformDirection(Vector3.forward) * Time.deltaTime * speed;
       // rigidbody.AddForce(speed);
       // rigidbody.velocity = speed;
        //rigidbody.
        Destroy(gameObject, 2.0f);

    //    time = time + Time.deltaTime;

    //    if (time > 5)
    //    {

    //    }
    }

    private void OnCollisionEnter(Collision collision)
    {

            
           // Destroy(collision.gameObject);

            //Switch this over to programs on the pillars end, and when they are hit, solve is set to true.
            Destroy(gameObject);

            
        
        
    }
}
