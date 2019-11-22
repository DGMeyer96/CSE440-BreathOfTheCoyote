using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
   
    public float maxHealth = 50;              // The amount of health the enemy starts the game with.
    public float currentHealth;                    // The current health the enemy has.


    Animator animate;                              // Reference to the animator.
           

    bool isDead;                                  // Whether the enemy is dead.

    void Awake()
    {
        // Setting up the references.
        animate = GetComponent<Animator>();
       
        // Setting the current health when the enemy first spawns.
        currentHealth = maxHealth;
    }

     void Update()
    {
        if (currentHealth <= 0)
            Dead();
    }

    public void Damage(float  damageAmount, Vector3 hitPoint)
    {
      


        // Reduce the current health by the amount of damage sustained.
        currentHealth -= damageAmount;



        // If the current health is less than or equal to zero...
       
    }

    void Dead()
    {
        // The enemy is dead.
        isDead = true;

        // Tell the animator that the enemy is dead.
        animate.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).



    }

}