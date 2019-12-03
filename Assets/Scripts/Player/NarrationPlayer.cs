using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class NarrationPlayer : MonoBehaviour
{
    //private AudioClip currentClip;
    private AudioSource NarrationSource;

    public AudioClip gameStart;
    public AudioClip mind;
    public AudioClip mindWin;
    public AudioClip strength;
    public AudioClip strengthWin;
    public AudioClip agility;
    public AudioClip agilityWin;
    public AudioClip gameWin;

    // Start is called before the first frame update
    void Start()
    {
        NarrationSource = GameObject.Find("NarrationSource").GetComponent<AudioSource>();
        NarrationSource.clip = gameStart;
        NarrationSource.PlayDelayed(5.0f);
        //currentClip = NarrationSource.clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "TrialOfMind" && GetComponent<Player>().TrialOfMind != true)
        {
            NarrationSource.clip = mind;
            NarrationSource.Play();
        }

        if (other.gameObject.name == "TrialOfStrength" && GetComponent<Player>().TrialOfStrength != true)
        {
            NarrationSource.clip = strength;
            NarrationSource.PlayDelayed(2.0f);
        }

        if (other.gameObject.name == "TrialOfAgility" && GetComponent<Player>().TrialOfAgility != true)
        {
            NarrationSource.clip = agility;
            NarrationSource.Play();
        }

        if (other.gameObject.name == "Mind Trophy" && GetComponent<Player>().TrialOfMind == true)
        {
            NarrationSource.clip = mindWin;
            NarrationSource.Play();
        }

        if (other.gameObject.name == "Strength Trophy" && GetComponent<Player>().TrialOfStrength == true)
        {
            NarrationSource.clip = strengthWin;
            NarrationSource.Play();
        }

        if (other.gameObject.name == "Agility Trophy" && GetComponent<Player>().TrialOfAgility == true)
        {
            NarrationSource.clip = agilityWin;
            NarrationSource.Play();
        }

        if (other.gameObject.name == "VillageEnter" && GetComponent<Player>().TrialOfAgility == true
            && GetComponent<Player>().TrialOfStrength == true && GetComponent<Player>().TrialOfMind == true)
        {
            NarrationSource.clip = gameWin;
            NarrationSource.Play();
        }
    }
}
