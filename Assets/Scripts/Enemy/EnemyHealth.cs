using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //private CharacterControl ccRef;
    public float maxHealth = 50;                    // The amount of health the enemy starts the game with.
    public float currentHealth;
    private float distance;
    public float maxDistance = 10f;
    public GameObject holder;
    public Animator animate;                        // Reference to the animator.
    private TriggerSpawn triggerSpawn;
    public Animator playerAnimator;
    public bool isDead;                             //Checks whether the enemy is Dead
    public bool isDamaged;                          //Checks whether enemy has been damaged
    public BoxCollider boxCollider;
    //Checks whether enemy has been damaged
    public GameObject player;
    



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
     
    }




    void Update()
    {
        transform.LookAt(player.transform);
        distance = Vector3.Distance(transform.position, player.transform.position);
        if(distance > maxDistance)
        {
            transform.position += transform.forward * 5 * Time.deltaTime;
            if(distance < maxDistance)
            {
                Debug.Log("I got here");
            }
        }
        
        
        
        
        //if (currentHealth <= 0)    //If current health is less than equal to 0 (enemy is dead)
            //Dead();
    }



    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Weapon" && playerAnimator.GetBool("FirstAttack") || 
            other.gameObject.tag == "Weapon" &&playerAnimator.GetBool("SecondAttack") ||
            other.gameObject.tag == "Weapon" && playerAnimator.GetBool("FinalAttack"))
        {
            Debug.Log(other.gameObject.name);
            currentHealth -= currentHealth;
            if(currentHealth <= 0)
            {
                    triggerSpawn.permanentSleep = true;
                    //other.gameObject.GetComponent<TriggerSpawn>().permanentSleep = true;
                    Debug.Log("Gets here: works");
                    Dead();
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

        // Tell the animator that the enemy is dead.
        animate.SetBool("Dead", true);

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).



    }
}