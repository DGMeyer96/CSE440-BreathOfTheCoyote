using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Fireball : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    private Animator fireSpawn;
    public Transform handLocation;
    public float cooldownTimer;
    public AudioSource BGMSource;



    // Start is called before the first frame update
    void Start()
    {
        
        speed = 5f;
        cooldownTimer = 0f;
        fireSpawn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        fireSpawn.SetBool("FireballAction", false);
        cooldownTimer += Time.deltaTime;

        if (cooldownTimer > 2.0f)          
        {
             if (Input.GetAxis("Fireball") > 0)
             {
                cooldownTimer = 0f;
                Debug.Log("runs");
                GameObject bullet = Instantiate(projectile, transform.position - 0.8f * transform.forward, Quaternion.identity);
                Debug.Log(bullet.transform.position);
                BGMSource.Play();

            }
        }
    }

    void fireballSpawn()
    {
        GameObject bullet = Instantiate(projectile, handLocation.position - 0.5f * handLocation.forward, Quaternion.identity);
        //fireSpawn.SetBool("FireballAction", false);
    }
}
