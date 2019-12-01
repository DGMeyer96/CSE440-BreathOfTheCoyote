using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FireballEnemy : MonoBehaviour
{
    public float speed;
    public GameObject projectile;
    private Animator fireSpawn;
    public Transform handLocation;
    public float cooldownTimer;
    public AudioSource BGMSource;
    //public Camera myCamera;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        
        cooldownTimer = 0f;
        //********New Animations here *****//
        //fireSpawn = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //********New Animations here *****//
        //fireSpawn.SetBool("FireballAction", false);
        cooldownTimer += Time.deltaTime;

        //******** Customize timer for spawning prefab, for now just spam that bitch *****//

        if (cooldownTimer > 2.0f)
        {
            
                cooldownTimer = 0f;
                //fireSpawn.SetBool("FireballAction", true);
                Invoke("fireballSpawn", 0.5f);
        }
    }

    void fireballSpawn()
    {
        GameObject bullet = Instantiate(projectile, handLocation.position + 2.0f * handLocation.forward, Quaternion.identity);
        bullet.GetComponent<Rigidbody>().velocity = (target.position - bullet.transform.position);
        Debug.Log(target.position - bullet.transform.position);
        BGMSource.Play();
        
       // float x = Screen.width / 2;
       // float y = Screen.height / 2;
       // var ray = myCamera.ScreenPointToRay(new Vector3(x, y, 0));
       // Debug.Log("ray is" + ray);
      //  bullet.GetComponent<Rigidbody>().velocity = ray.direction * speed;
        //fireSpawn.SetBool("FireballAction", false);
    }
}