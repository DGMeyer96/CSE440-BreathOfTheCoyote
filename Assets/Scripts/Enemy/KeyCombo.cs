/*
  Combo script for both player and enemy that will allow three combo moves to be executed
  Combo moves for player will be determined by buttons pressed
  Combo moves for enemy ai will be auto generated every five seconds
  Checks for enemy ai combo:
     (1.) isenemybeinghit
     (2.) isplayerbeing hit
     (3.) isplayerinrange
     (4.) isattack
 */
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KeyCombo : MonoBehaviour
{
    Animator meleeAction;
    private int attackCounter;
    private float cooldown;
    private float reset;

    public float weaponDamage;

    void Start()
    {
        meleeAction = gameObject.GetComponent<Animator>();
    }

    //Weapon animations and giving damage to the Weapon
    void Update()
    {
        if (cooldown > 0.5f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cooldown = 0;
                Attack();
            }
        }
        cooldown += Time.deltaTime;

        if (reset > 3f)
        {
            reset = 0f;
            attackCounter = 0;
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", false);
            meleeAction.SetBool("FinalAttack", false);

        }

        reset += Time.deltaTime;
    }


    private void Attack()
    {
        if (attackCounter == 0)
        {



            meleeAction.SetBool("FirstAttack", true);
            attackCounter = 1;
            weaponDamage = 2f;
            reset = 1f;
        }
        else if (attackCounter == 1)
        {
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", true);
            attackCounter = 2;
            weaponDamage = 2f;
            reset = 1f;
        }

        else if (attackCounter == 2)
        {
            meleeAction.SetBool("SecondAttack", false);
            meleeAction.SetBool("FinalAttack", true);
            weaponDamage = 5f;
            reset = 2.5f;
        }
    }
}
