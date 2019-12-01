﻿using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //private CharacterControl ccRef;
    public float maxHealth = 15;                    // The amount of health the enemy starts the game with.
    public float currentHealth;
    public float fireballDamage = 8;
    public float damageTaken = 5;
    public float maxDistance = 10;
    public int damageDealt = 1;
    public float cooldown;
    public float distance;
    public GameObject holder;
    public GameObject player;
    private TriggerSpawn triggerSpawn;
    private Animator playerAnimator;
    public Animator animate;
    public bool isDead;                             //Checks whether the enemy is Dead
    public bool isDamaged;
    public bool stupidboolname;
    public bool johnCena;
    public BoxCollider boxCollider;

    private AudioSource enemyWalking;
    private AudioSource enemyHit;
    private AudioSource enemyMelee;
    private AudioSource enemyDeath;

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

        enemyDeath = GameObject.Find("EnemyDeath").GetComponent<AudioSource>();
        enemyMelee = GameObject.Find("EnemyMelee").GetComponent<AudioSource>();
        enemyHit = GameObject.Find("EnemyHit").GetComponent<AudioSource>();
        enemyWalking = GameObject.Find("EnemyWalking").GetComponent<AudioSource>();
    }

    void Update()
    {
        if (johnCena)
        {
            animate.SetBool("TakingHit", true);
            johnCena = false;

            //enemyWalking.Stop();
            //enemyHit.Play();
        }
        else if (animate.GetBool("TakingHit") && johnCena == false)
        {
            Debug.Log("It reached");
            animate.SetBool("TakingHit", false);

            //enemyHit.Stop();
        }

        cooldown += Time.deltaTime;

        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance)
        {
            animate.SetBool("Idle", false);
            animate.SetBool("Movement", true);
            transform.position += transform.forward * 5 * Time.deltaTime;
            //  Debug.Log(transform.position);

            if (!enemyWalking.isPlaying)
            {
                //enemyWalking.Play();
            }

        }

        else if (distance <= maxDistance)
        {
            if (cooldown >= 3f)
            {
                Debug.Log("Attack Cooldown: " + cooldown);

                animate.SetBool("Idle", false);
                animate.SetBool("Movement", false);
                animate.SetBool("Attack", true);

                cooldown = 0f;
            }
            if (cooldown > 0.7f && cooldown < 3f)
            {
                animate.SetBool("Attack", false);
            }
        }

        if (currentHealth <= 0)
        {
            //enemyDeath.Play();
            animate.Play("Die");
            Invoke("Dead", 2.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Weapon" && playerAnimator.GetInteger("AttackValue") == 1 ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetInteger("AttackValue") == 2 ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetInteger("AttackValue") == 3)
        {

            currentHealth -= damageTaken;
            johnCena = true;
            animate.SetBool("Attack", false);

            Debug.Log("Hit By:" + other.gameObject.name);

            other.gameObject.GetComponent<AudioSource>().Play();
        }

        else if (other.gameObject.GetComponent<FireballMovement>() != null)
        {
            currentHealth -= fireballDamage;
            animate.SetBool("Attack", false);
            johnCena = true;

        }

        else if (other.gameObject.tag == "Player" && animate.GetBool("Attack"))
        {
            //other.gameObject.GetComponent<Player>().health -= damageDealt;
            //Debug.Log(other.gameObject.GetComponent<Player>().health);
            other.gameObject.GetComponent<Player>().DamagePlayer(damageDealt);
            //cooldown = 0f;
        }

    }

    void Dead()
    {
        triggerSpawn.permanentSleep = true;
        Destroy(gameObject);
    }
}