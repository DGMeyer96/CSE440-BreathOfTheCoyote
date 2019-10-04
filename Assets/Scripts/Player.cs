using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public bool LeftVillage;
    public bool TrialOfStrength;
    public bool TrialOfMind;
    public bool TrialOfAgility;
    public Vector3 position;
    public string saveName;
    public float playTime = 0.0f;
    public string playDate;

    public void NewGame()
    {
        health = 10;
        LeftVillage = false;
        TrialOfStrength = false;
        TrialOfMind = false;
        TrialOfAgility = false;
        playTime = 0.0f;

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
        TrialOfMind = data.TrialOfMind;
        TrialOfAgility = data.TrialOfAgility;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        saveName = data.saveName;
        playTime = data.playTime;
        playDate = data.playDate;

        PrintPlayerData();
    }

    public void PrintPlayerData()
    {
        Debug.Log("Health: " + health + "\n"
                    + "Position X: " + position.x.ToString() + "\n"
                    + "Position Y: " + position.y.ToString() + "\n"
                    + "Position Z: " + position.z.ToString() + "\n"
                    + "Trial Of Strength: " + TrialOfStrength.ToString() + "\n"
                    + "Trial of Mind: " + TrialOfMind.ToString() + "\n"
                    + "Trial of Agility: " + TrialOfAgility.ToString() + "\n"
                    + "Play Time: " + playTime + "\n");
    }
}
