using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject playerObject;
    public Canvas gameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        if (player != null)
        {
            Debug.Log("Found Player");
            player.health = 10;
        }

        //EnableMenus();
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
            playerObject.transform.position = player.playerPosition;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //SetupMenus();

        if(player.health == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    public void GameWin()
    {
        Debug.Log("YOU WIN!");
    }

    
}
