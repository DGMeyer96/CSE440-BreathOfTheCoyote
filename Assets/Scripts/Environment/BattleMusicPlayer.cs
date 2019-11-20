using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMusicPlayer : MonoBehaviour
{
    private int triggerNum = 0;
    private AudioClip currentClip;

    public AudioClip battleClip;
    public AudioSource BGMSource;

    private void Start()
    {
        currentClip = BGMSource.clip;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "TrialOfStrength" || other.gameObject.tag == "Combat")
        {
            BGMSource.clip = battleClip;
            BGMSource.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "TrialOfStrength" || other.gameObject.tag == "Combat")
        {
            BGMSource.Stop();
            BGMSource.clip = currentClip;
            BGMSource.Play();
        }
    }
}
