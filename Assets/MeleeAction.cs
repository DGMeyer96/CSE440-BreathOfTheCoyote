using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAction : MonoBehaviour
{
    Animator meleeAction;
    private int attackCounter;
    private float cooldown;
    private float reset;
    
    
    

    void Start()
    {
        meleeAction = gameObject.GetComponent<Animator>();
        
    }

    // Update is called once per frame

    void Update()
    {
        if(cooldown > 0.5f)
        {
            if (Input.GetMouseButtonDown(0))
            {
                cooldown = 0;
                Attack();
            }

            if (Input.GetMouseButtonDown(1))
            {
                Fireball();
            }
        }
        cooldown += Time.deltaTime;

        if(reset > 1f)
        {
            meleeAction.SetBool("Fireball", false);
        }
        if(reset > 3f)
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
        if(attackCounter == 0)
        {
            
            meleeAction.SetBool("FirstAttack", true);
            attackCounter = 1;
            reset = 0f;
        }
        else if (attackCounter == 1)
        {
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", true);
            attackCounter = 2;
            reset = 0f;
        }

        else if (attackCounter == 2)
        {
            meleeAction.SetBool("SecondAttack", false);
            meleeAction.SetBool("FinalAttack", true);
            reset = 0f;
        }

       
    /*if (Input.GetMouseButtonDown(0) && attackCounter == 0)
        {
            meleeAction.SetBool("FirstAttack", true);
            attackCounter++;
            
        }

        else if (Input.GetMouseButtonDown(0) && attackCounter == 1)
        {
            meleeAction.SetBool("SecondAttack", true);
            attackCounter++;
        }

        else if (attackCounter == 2)
        {
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", false);
            meleeAction.SetBool("StopAttack", true);
            attackCounter = 0;
        }*/
    }

    private void Fireball()
    {
        meleeAction.SetBool("Fireball", true);
    }

}
