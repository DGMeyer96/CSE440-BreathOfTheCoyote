using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    //private CharacterControl ccRef;
    public float maxHealth = 50;                    // The amount of health the enemy starts the game with.
    public float currentHealth;                    // The current health the enemy has.
    //public slider heartSlider;

    public Animator animate;                              // Reference to the animator.


    bool isDead;                                  //Checks whether the enemy is Dead
    public bool isDamaged;
    //Checks whether enemy has been damaged

    public GameObject player;





    void Start()
    {
        player = GameObject.FindWithTag("Player");
        animate = GetComponent<Animator>();
        currentHealth = maxHealth;
     //   ccRef = GetComponent<CharacterControl>();
    }




    void Update()
    {
        transform.LookAt(player.transform);
        transform.Translate(0, 0, 8 * Time.deltaTime);
        //if (currentHealth <= 0)    //If current health is less than equal to 0 (enemy is dead)
            //Dead();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Weapon")
        {
            currentHealth -= currentHealth;
            if(currentHealth <= 0)
            {
                collision.gameObject.GetComponent<TriggerSpawn>().permanentSleep = true;
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
        
        

        // Tell the animator that the enemy is dead.
        animate.SetBool("Dead", true);

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).



    }
}