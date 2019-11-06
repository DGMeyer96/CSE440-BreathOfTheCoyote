using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    public float cooldownTimer;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        cooldownTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.E))
        {
           // if (cooldownTimer > 2.0f)

             {
                cooldownTimer = 0f;

                GameObject bullet = Instantiate(projectile, transform.position + 2 * transform.forward, Quaternion.identity);


            }
        }
    }
}
