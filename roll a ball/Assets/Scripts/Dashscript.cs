using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dashscript : MonoBehaviour
{

    float timerdash;
    float timetodash = 500;
    bool candash = true;
    private Rigidbody rb;
    public float dashSpeed = 400f;

    // Start is called before the first frame update
    void Start()
    {
        timerdash = 0;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) && candash)
        {
            float timer = 0;
            candash = false;
            float totaltime = 30;
            while (timer < totaltime)
            {
                timer += Time.fixedDeltaTime;
                float moveVertical = Input.GetAxis("Vertical");
                float moveHorizontal = Input.GetAxis("Horizontal");
                Vector3 movementd = new Vector3(moveHorizontal, 0.0f, moveVertical);
                movementd = movementd * dashSpeed * Time.deltaTime;
                movementd = transform.worldToLocalMatrix.inverse * movementd;
                rb.MovePosition(transform.position + movementd);
            }
            timer = 0;
        }
        if (!candash)
        {
            timerdash += 1;
            if (timerdash >= timetodash)
            {
                timerdash = 0;
                candash = true;
            }
        }

    }
}
