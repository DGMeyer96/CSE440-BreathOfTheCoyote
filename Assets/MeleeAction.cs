using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAction : MonoBehaviour
{
    Animator meleeAction;
    private int weaponCounter = 0;
    

    void Start()
    {
        meleeAction = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && weaponCounter == 0)
        {
            meleeAction.SetBool("FirstAttack", true);
            weaponCounter = 1;
        }

        else if(Input.GetMouseButton(0) && weaponCounter == 1)
        {
            meleeAction.SetBool("SecondAttack", true);
            weaponCounter = 0;
                
        }
        else
        {
            meleeAction.SetBool("FirstAttack", false);
            meleeAction.SetBool("SecondAttack", false);
            
        }

        /*else if(Input.GetMouseButtonDown(0) && weaponCounter == 1)
        {
            meleeAction.SetBool("SecondAttack", true);
            weaponCounter = 2;
        }*/

        //if (Input.GetMouseButton(0))
        //{
        //    meleeAction.SetBool("FirstAttack", false);
        //    //meleeAction.SetBool("SecondAttack", false);
        //}
    }
}
