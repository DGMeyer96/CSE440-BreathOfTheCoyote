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

public class KeyCombo
{
    public string[] buttons; // set up an array for the series of buttons player must hit within allowed time to activate combo
    private int currentIndex = 0; //keep an index of the buttons player has/is pressed/pressing
    public float allowedTimeBetweenButtons = 0.5f; //the amount of time allowed to press between buttons to keep combo buildup alive
    private float timeLastButtonPressed; //we need to keep a floating time of when the last button press was

    public KeyCombo(string[] b)
    {
        buttons = b;
    }

    // Combo Function, returns true if player successfully completed the series of button presses.
    public bool Check()
    {
        if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex = 0;
        {
            if (currentIndex < buttons.Length)
            {  
                
                {
                    timeLastButtonPressed = Time.time; //keep track of button press delays
                    currentIndex++;
                }

                if (currentIndex >= buttons.Length)
                {
                    currentIndex = 0;
                    return true; // Combo was successfully completed
                }
                else return 
                      false; // failed
            }
        }
        
    }

}
