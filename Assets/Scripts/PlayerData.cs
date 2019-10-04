using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int health;
    public float[] position;
    public bool LeftVillage;
    public bool TrialOfStrength;
    public bool TrialOfMind;
    public bool TrialOfAgility;
    public string saveName;
    public float playTime;
    public string playDate;

    public PlayerData(Player player)
    {
        health = player.health;

        position = new float[3];
        position[0] = player.transform.position.x;
        position[1] = player.transform.position.y;
        position[2] = player.transform.position.z;

        LeftVillage = player.LeftVillage;
        TrialOfStrength = player.TrialOfStrength;
        TrialOfMind = player.TrialOfMind;
        TrialOfAgility = player.TrialOfAgility;

        saveName = player.saveName;
        playTime = player.playTime;
        playDate = player.playDate;
    }
}
