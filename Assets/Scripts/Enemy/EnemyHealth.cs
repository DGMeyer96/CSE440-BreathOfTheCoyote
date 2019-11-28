using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //private CharacterControl ccRef;
    public float maxHealth = 15;                    // The amount of health the enemy starts the game with.
    public float currentHealth;
    public float fireballDamage = 8;
    public float damageTaken = 5;
    public float maxDistance = 15;
    public float distance;
    public GameObject holder;
    public GameObject player;
    private TriggerSpawn triggerSpawn;
    public Animator playerAnimator;
    public Animator animate;
    public bool isDead;                             //Checks whether the enemy is Dead
    public bool isDamaged;
    public bool stupidboolname;
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
        animate.SetBool("Attack", false);
        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if (distance > maxDistance)
        {
            
            animate.SetBool("Movement", true);
            transform.position += transform.forward * 5 * Time.deltaTime;
            //  Debug.Log(transform.position);
           
        }

        else if (distance <= maxDistance)
        {

            animate.SetBool("Movement", false);
            animate.SetBool("Attack", true);
        }

        if (currentHealth <= 0)
        {
            triggerSpawn.permanentSleep = true;
            Dead();
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.tag == "Weapon" && playerAnimator.GetBool("FirstAttack") ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetBool("SecondAttack") ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetBool("FinalAttack"))
        {
            stupidboolname = false;

            Debug.Log(other.gameObject.name);
            currentHealth -= damageTaken;
            
            if (currentHealth <= 0)
            {
                triggerSpawn.permanentSleep = true;
                Dead();
            }
        }

        if (other.gameObject.GetComponent<FireballMovement>() != null)
        {
            currentHealth -= fireballDamage;
            Debug.Log(currentHealth);
            if (currentHealth <= 0)
            {
                triggerSpawn.permanentSleep = true;
                animate.SetBool("Dead", true);
                Invoke("Dead", 1.0f);
            }

        }
       


        if (other.gameObject.tag == "Player")
        {
            if (animate.GetBool("Attack"))
            {
                other.gameObject.GetComponent<PlayerHealth>().currentHealth -= other.gameObject.GetComponent<PlayerHealth>().damageTaken;
            }
        }
    }
    public void Damage(float damageAmount, Vector3 hitPoint)
    {
        //The enemy is damaged
        isDamaged = true;

        // Reduce the current health by the amount of damage sustained.
        currentHealth -= damageAmount;



        // If the current health is less than or equal to zero...

    }

    void Dead()
    {
        // The enemy is dead.

        Destroy(gameObject);

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).



    }
}