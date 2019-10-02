using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public bool LeftVillage;
    public bool TrialOfStrength;
    public bool TrialsOfMind;
    public bool TrialOfAgility;
    public Vector3 position;
    public string saveName;
    public string playTime;
    public string playDate;

    public void NewGame()
    {
        SaveSystem.NewPlayerData(this);
    }

    public void SaveGame()
    {
        SaveSystem.SavePlayerData(this);
    }

    public void LoadGame()
    {
        PlayerData data = SaveSystem.LoadPlayerData(saveName);

        health = data.health;
        LeftVillage = data.LeftVillage;
        TrialOfStrength = data.TrialOfStrength;
        TrialsOfMind = data.TrialsOfMind;
        TrialOfAgility = data.TrialOfAgility;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        saveName = data.saveName;
        playTime = data.playTime;
        playDate = data.playDate;
    }
}
