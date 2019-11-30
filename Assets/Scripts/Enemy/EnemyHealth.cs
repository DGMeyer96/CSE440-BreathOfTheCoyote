﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //private CharacterControl ccRef;
    public float maxHealth = 15;                    // The amount of health the enemy starts the game with.
    public float currentHealth;
    public float fireballDamage = 8;
    public float damageTaken = 5;
    public float maxDistance = 15;
    public int damageDealt = 1;
    public float cooldown;
    public float distance;
    public GameObject holder;
    public GameObject player;
    private TriggerSpawn triggerSpawn;
    public Animator playerAnimator;
    public Animator animate;
    public bool isDead;                             //Checks whether the enemy is Dead
    public bool isDamaged;
    public bool stupidboolname;
    public bool johnCena;
    public BoxCollider boxCollider;
   





    void Awake()
    {
        animate = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        

        currentHealth = maxHealth;

    }

    void Start()
    {
        holder = GameObject.Find("TrialOfStrength");
        triggerSpawn = holder.GetComponent<TriggerSpawn>();
        player = GameObject.FindWithTag("Player");
        playerAnimator = player.GetComponent<Animator>();
        animate.SetBool("Idle", true);
     //   goddamnitihavetoaddanotherbool = true;


    }




    void Update()
    {

        cooldown += Time.deltaTime;
        animate.SetBool("Attack", false);
        
        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance)
        {
            animate.SetBool("Idle", false);
            animate.SetBool("Movement", true);
            transform.position += transform.forward * 5 * Time.deltaTime;
            //  Debug.Log(transform.position);
           
        }

        else if (distance <= maxDistance)
        {
            if (cooldown > 4f)
            {
                animate.SetBool("Movement", false);
                animate.SetBool("Attack", true);
                
            }
        }

        if(currentHealth < 0)
        {
            animate.Play("Die");
            Invoke("Dead", 2.0f);
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" && playerAnimator.GetBool("FirstAttack") ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetBool("SecondAttack") ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetBool("FinalAttack"))
        {

            currentHealth -= damageTaken;
            animate.SetBool("Attack", false);
            animate.SetBool("TakingHit", true);
        }

        if (other.gameObject.GetComponent<FireballMovement>() != null)
        {
            currentHealth -= fireballDamage;
            animate.SetBool("Attack", false);
            animate.SetBool("TakingHit", true);
        }

        if (other.gameObject.tag == "Player" && animate.GetBool("Attack"))
        {
            other.gameObject.GetComponent<Player>().health -= damageDealt;
        }
    }

 
    void Dead()
    {

        johnCena = true;
        triggerSpawn.permanentSleep = true;
        Destroy(gameObject);
    }
}