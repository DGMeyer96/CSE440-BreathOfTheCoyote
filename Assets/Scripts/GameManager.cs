using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
            Debug.Log("Found Player");

        player.saveName = PlayerPrefs.GetString("SaveGameName");
        Debug.Log("Save Game Name: " + player.saveName);

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

        if (PlayerPrefs.GetInt("NewGame") == 1)
        {
            player.NewGame();
            PlayerPrefs.SetInt("NewGame", 0);
        }
        else
        {
            player.LoadGame();
            playerObject.transform.position = player.position;
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
