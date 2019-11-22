using UnityEngine;
using System.Collections;

public class comboTest : MonoBehaviour
{
    private KeyCombo warHammer = new KeyCombo(new string[] { "stuff", "stuff", "stuff", "stuff" });
    private KeyCombo battleAxe = new KeyCombo(new string[] { "stuff", "stuff", "stuff", "stuff" });
    private KeyCombo fireball = new KeyCombo(new string[] { "stuff", "stuff", "stuff", "stuff", "stuff", "stuff" });

    void Update()
    {
        if (warHammer.Check())
        {
            //do combo1 stuff
            Debug.Log("War Hammer Combo activated");
        }
        if (battleAxe.Check())
        {
            // do combo2 stuff
            Debug.Log("Battle Axe Combo activated");
        }
        if (fireball.Check())
        {
            // do Kick to the face combo stuff
            Debug.Log("Fireball Combo activated");
        }
    }
}
