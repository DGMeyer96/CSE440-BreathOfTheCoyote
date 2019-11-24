using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Fireball : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    private Animator fireballAnimation;
    public float cooldownTimer;
    public Transform fireballSpawn;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
        cooldownTimer = 0f;
        fireballAnimation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fireballAnimation.SetBool("FireballAction", false);
        cooldownTimer += Time.deltaTime;
        if (cooldownTimer > 2.0f)
           
        {
             if (Input.GetAxis("Fireball") > 0)

             {
                cooldownTimer = 0f;
                fireballAnimation.SetBool("FireballAction", true);
                GameObject bullet = Instantiate(projectile, transform.position + 0.7f * transform.forward, Quaternion.identity);
                Debug.Log("Shoot");


            }
        }
    }
}
