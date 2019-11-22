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



    void Start()
    {
        currentHealth = maxHealth;
     //   ccRef = GetComponent<CharacterControl>();
    }




    void Update()
    {
        if (currentHealth <= 0)    //If current health is less than equal to 0 (enemy is dead)
            Dead();
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
        isDead = true;

        // Tell the animator that the enemy is dead.
        animate.SetTrigger("Dead");

        // Change the audio clip of the audio source to the death clip and play it (this will stop the hurt clip playing).



    }

}