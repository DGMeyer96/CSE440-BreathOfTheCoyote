using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int    startingHealth = 100;                          
    public int    currentHealth;                                   
    public Slider heartSlider;                                 // Reference to the UI's health bar.                                   
                            
    
   Animator animate;                                              // Reference to the Animator component.                                 
    //PlayerController playerController;                        //Reference to Ben's Player Controller Script(Commented out since I didnt download that script yet.)                            
    bool isDead;                                               
    bool isDamaged;

    void Awake()
    {
        // Setting up the references.
        animate = GetComponent<Animator>();
       // playerAudio = GetComponent<AudioSource>();
       // playerController = GetComponent<PlayerController>();
       

        // Set the initial health of the player.
        currentHealth = startingHealth;
    }



    public void TakeDamage(int damageAmount)
    {
       
        isDamaged = true;

        // Reduces the current health by the damage amount.(Player will be damaged at 10 points per strike)
        currentHealth -= damageAmount;

        // Set the health bar's value to the current health. (Basically will reduce health by one heart)
        heartSlider.value = currentHealth;

    
        // If the player has lost all it's health and the death flag hasn't been set yet...
        if (currentHealth <= 0 && !isDead)
        {
            // Enemy is dead
            Dead();
        }
    }


    void Dead()
    {
        // Will set the death flag to true so this function can't be called again.
        isDead = true;

     
        // Tells the animator that the player is dead.
        animate.SetTrigger("Dead");

    
       
    }
}

