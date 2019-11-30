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

    public int attackValue = 0;
    private bool combo = false;
    private bool startTimer = false;
    private float timer = 0.0f;

    int numClicks;
    bool canClick;

    void Start()
    {
        meleeAction = gameObject.GetComponent<Animator>();
        numClicks = 0;
        canClick = true;
    }

    //Weapon animations and giving damage to the Weapon
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ComboStarter();
        }

        /*
        //if (cooldown > 0.5f)
        //{
            if (Input.GetMouseButtonDown(0))
            {
                cooldown = 0;
                meleeAction.SetInteger("AttackValue", 1);
                //Attack();
            }
        //}
        cooldown += Time.fixedDeltaTime;

        if (reset >= 4f)
        {
            reset = 0f;
            attackCounter = 0;
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", false);
            meleeAction.SetBool("FinalAttack", false);

        }

        reset += Time.fixedDeltaTime;


        if (startTimer == true)
        {
            TimerFunc();
        }
        else
        {
            timer = 0.0f;
        }
        */
    }


    private void Attack()
    {
        if (attackCounter == 0)
        {
            meleeAction.SetBool("FirstAttack", true);
            meleeAction.SetBool("SecondAttack", false);
            meleeAction.SetBool("FinalAttack", false);
            attackCounter = 1;
            weaponDamage = 2f;
            reset = 2.5f;
        }
        else if (attackCounter == 1)
        {
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", true);
            meleeAction.SetBool("FinalAttack", false);
            attackCounter = 2;
            weaponDamage = 2f;
            reset = 2.5f;
        }

        else if (attackCounter == 2)
        {
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", false);
            meleeAction.SetBool("FinalAttack", true);
            weaponDamage = 5f;
            reset = 2f;
            attackCounter = 0;
        }
    }

    /*
    public void Attack1Done()
    {
        Debug.Log("Attack 1 Done");
        startTimer = true;
        //meleeAction.SetInteger("AttackValue", 2);

    }

    public void Attack2Done()
    {
        Debug.Log("Attack 2 Done");
        //meleeAction.SetInteger("AttackValue", 3);
        startTimer = true;
    }

    public void Attack3Done()
    {
        Debug.Log("Attack 3 Done");
        meleeAction.SetInteger("AttackValue", 0);
    }
    
    public void TimerFunc()
    {
        timer += Time.fixedDeltaTime;
        Debug.Log(timer);

        if(timer >= 1.0f)
        {
            startTimer = false;
            meleeAction.SetInteger("AttackValue", 0);
        }

        if (Input.GetMouseButtonDown(0) && meleeAction.GetInteger("AttackValue") == 1)
        {
            startTimer = false;
            meleeAction.SetInteger("AttackValue", 2);
        }

        if (Input.GetMouseButtonDown(0) && meleeAction.GetInteger("AttackValue") == 2)
        {
            startTimer = false;
            meleeAction.SetInteger("AttackValue", 3);
        }
    }
    */

    public void ComboStarter()
    {
        if(canClick)
        {
            numClicks++;
        }

        if(numClicks == 1)
        {
            meleeAction.SetInteger("AttackValue", 1);
        }
    }

    public void ComboCheck()
    {
        canClick = false;

        if(meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack1") && numClicks == 1)
        {
            meleeAction.SetInteger("AttackValue", 0);
            canClick = true;
            numClicks = 0;
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack1") && numClicks >= 2)
        {
            meleeAction.SetInteger("AttackValue", 2);
            canClick = true;
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack2") && numClicks == 2)
        {
            meleeAction.SetInteger("AttackValue", 0);
            canClick = true;
            numClicks = 0;
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack2") && numClicks >= 3)
        {
            meleeAction.SetInteger("AttackValue", 3);
            canClick = true;
        }
        else if (meleeAction.GetCurrentAnimatorStateInfo(0).IsName("PlayerCharacter_Attack3"))
        {
            meleeAction.SetInteger("AttackValue", 0);
            canClick = true;
            numClicks = 0;
        }
    }
}
