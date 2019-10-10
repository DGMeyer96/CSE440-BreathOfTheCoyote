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
    public Canvas menuCanvas;
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject newGameMenu;
    public GameObject loadGameMenu;

    public Texture2D dataErrorTex;
    public Texture2D dataFoundTex;

    private bool inMenu = true;
    private string saveGameName;

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
        //player.saveName = PlayerPrefs.GetString("SaveGameName");
       // Debug.Log("Save Game Name: " + player.saveName);

        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");

        /*
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
        */
        gameCanvas.gameObject.SetActive(false);

        mainMenu.gameObject.SetActive(true);
        optionsMenu.gameObject.SetActive(false);
        newGameMenu.gameObject.SetActive(false);
        loadGameMenu.gameObject.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        //SetupMenus();

        if(player.health == 0)
        {
            GameOver();
        }

        if (inMenu || gameCanvas.GetComponent<PauseHandler>().GetGamePaused())
            EnableMenus();
        else
            DisableMenus();
    }

    public void GameOver()
    {
        Debug.Log("GAME OVER");
    }

    public void GameWin()
    {
        Debug.Log("YOU WIN!");
    }

    public void EnableMenus()
    {
        player.GetComponent<CompassHandler>().enabled = false;
        player.GetComponent<Dashscript>().enabled = false;
        player.GetComponent<Jumpscript>().enabled = false;
        player.GetComponent<PlayerController_OLD>().enabled = false;
        player.GetComponentInChildren<eyelook>().enabled = false;
    }

    void DisableMenus()
    {
        mainMenu.gameObject.SetActive(true);
        gameCanvas.gameObject.SetActive(true);
        menuCanvas.gameObject.SetActive(false);

        player.GetComponent<CompassHandler>().enabled = true;
        player.GetComponent<Dashscript>().enabled = true;
        player.GetComponent<Jumpscript>().enabled = true;
        player.GetComponent<PlayerController_OLD>().enabled = true;
        player.GetComponentInChildren<eyelook>().enabled = true;
    }

    public void MainMenu(GameObject prevMenu)
    {
        mainMenu.gameObject.SetActive(true);
        prevMenu.gameObject.SetActive(false);
    }

    public void NewGameMenu()
    {
        //Debug.Log("[GAMEMANAGER] New Game Menu");

        //Active newGameMenu UI and deactivate mainMenu UI
        newGameMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);

        //Get refrences to each save game UI element (contains image and text description)
        GameObject saveGame1 = GameObject.Find("SaveGame1");
        //Debug.Log("[GAMEMANAGER] Found SaveGame1");
        GameObject saveGame2 = GameObject.Find("SaveGame2");
        //Debug.Log("[GAMEMANAGER] Found SaveGame2");
        GameObject saveGame3 = GameObject.Find("SaveGame3");
        //Debug.Log("[GAMEMANAGER] Found SaveGame3");

        //Get existing player data
        PlayerData save1 = SaveSystem.LoadPlayerData("Save1.sav");
        //Debug.Log("[GAMEMANAGER] " + save1.saveName);
        PlayerData save2 = SaveSystem.LoadPlayerData("Save2.sav");
        //Debug.Log("[GAMEMANAGER] " + save2.saveName);
        PlayerData save3 = SaveSystem.LoadPlayerData("Save3.sav");
        //Debug.Log("[GAMEMANAGER] " + save3.saveName);

        Texture2D tex = new Texture2D(2,2);

        //Check if Player Data exists
        if (save1 != null)
        {
            //Set image to saved image
            tex = new Texture2D(2, 2);
            tex.LoadImage(save1.texData);
            saveGame1.transform.GetChild(0).GetComponent<RawImage>().texture = tex;
            //saveGame1.transform.GetChild(0).GetComponent<RawImage>().texture = dataFoundTex;
            //Set description text to saved date and time
            saveGame1.transform.GetChild(2).GetComponent<Text>().text = "Play Time: " + save1.playTime + "\n" + "Date: " + save1.playDate;
            Debug.Log("[GAMEMANAGER] " + "Play Time: " + player.playTime + " Date: " + player.playDate);
        }
        else
        {
            Debug.Log("[GAMEMANAGER] No save found");
            tex = new Texture2D(2, 2);
            //No existing Player Data, use defaults
            saveGame1.transform.GetChild(0).GetComponent<RawImage>().texture = dataErrorTex;
            saveGame1.transform.GetChild(2).GetComponent<Text>().text = "Play Time: N/A" + "\n" + "Date: N/A";
        }

        if (save2 != null)
        {
            tex = new Texture2D(2, 2);
            tex.LoadImage(save2.texData);
            //Set image to saved image
            saveGame2.transform.GetChild(0).GetComponent<RawImage>().texture = tex;
            //saveGame2.transform.GetChild(0).GetComponent<RawImage>().texture = dataFoundTex;
            //Set description text to saved date and time
            saveGame2.transform.GetChild(2).GetComponent<Text>().text = "Play Time: " + save2.playTime + "\n" + "Date: " + save2.playDate;
        }
        else
        {
            tex = new Texture2D(2, 2);
            //No existing Player Data, use defaults
            saveGame2.transform.GetChild(0).GetComponent<RawImage>().texture = dataErrorTex;
            saveGame2.transform.GetChild(2).GetComponent<Text>().text = "Play Time: N/A" + "\n" + "Date: N/A";
        }

        if (save3 != null)
        {
            tex = new Texture2D(2, 2);
            tex.LoadImage(save3.texData);
            //Set image to saved image
            saveGame3.transform.GetChild(0).GetComponent<RawImage>().texture = tex;
            //saveGame3.transform.GetChild(0).GetComponent<RawImage>().texture = dataFoundTex;
            //Set description text to saved date and time
            saveGame3.transform.GetChild(2).GetComponent<Text>().text = "Play Time: " + save3.playTime + "\n" + "Date: " + save3.playDate;
        }
        else
        {
            tex = new Texture2D(2, 2);
            //No existing Player Data, use defaults
            saveGame3.transform.GetChild(0).GetComponent<RawImage>().texture = dataErrorTex;
            saveGame3.transform.GetChild(2).GetComponent<Text>().text = "Play Time: N/A" + "\n" + "Date: N/A";
        }
    }

    public void LoadGameMenu()
    {
        loadGameMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);

        //Get refrences to each save game UI element (contains image and text description)
        GameObject loadGame1 = GameObject.Find("LoadGame1");
        GameObject loadGame2 = GameObject.Find("LoadGame2");
        GameObject loadGame3 = GameObject.Find("LoadGame3");

        //Get existing player data
        PlayerData load1 = SaveSystem.LoadPlayerData("Save1.sav");
        PlayerData load2 = SaveSystem.LoadPlayerData("Save2.sav");
        PlayerData load3 = SaveSystem.LoadPlayerData("Save3.sav");

        Texture2D tex = new Texture2D(2, 2);

        //Check if Player Data exists
        if (load1 != null)
        {
            Debug.Log("Load 1 found");
            Debug.Log(loadGame1.ToString());
            //Set image to saved image

            tex = new Texture2D(2, 2);
            tex.LoadImage(load1.texData);
            loadGame1.transform.GetChild(0).GetComponent<RawImage>().texture = tex;
            //loadGame1.transform.GetChild(0).GetComponent<RawImage>().texture = dataFoundTex;
            //Set description text to saved date and time
            loadGame1.transform.GetChild(2).GetComponent<Text>().text = "Play Time: " + load1.playTime + "\n" + "Date: " + load1.playDate;
            Debug.Log("Play Time: " + player.playTime + "\n" + "Date: " + player.playDate);
        }
        else
        {
            tex = new Texture2D(2, 2);
            //No existing Player Data, use defaults
            loadGame1.transform.GetChild(0).GetComponent<RawImage>().texture = dataErrorTex;
            loadGame1.transform.GetChild(2).GetComponent<Text>().text = "Play Time: N/A" + "\n" + "Date: N/A";
        }

        if (load2 != null)
        {
            Debug.Log("Load 2 found");
            Debug.Log(loadGame2.ToString());

            tex = new Texture2D(2, 2);
            tex.LoadImage(load2.texData);
            //Set image to saved image
            loadGame2.transform.GetChild(0).GetComponent<RawImage>().texture = tex;
            //loadGame2.transform.GetChild(0).GetComponent<RawImage>().texture = dataFoundTex;
            //Set description text to saved date and time
            loadGame2.transform.GetChild(2).GetComponent<Text>().text = "Play Time: " + load2.playTime + "\n" + "Date: " + load2.playDate;
        }
        else
        {
            tex = new Texture2D(2, 2);
            //No existing Player Data, use defaults
            loadGame2.transform.GetChild(0).GetComponent<RawImage>().texture = dataErrorTex;
            loadGame2.transform.GetChild(2).GetComponent<Text>().text = "Play Time: N/A" + "\n" + "Date: N/A";
        }

        if (load3 != null)
        {
            Debug.Log("Load 3 found");
            Debug.Log(loadGame3.ToString());

            tex = new Texture2D(2, 2);
            tex.LoadImage(load3.texData);
            //Set image to saved image
            loadGame3.transform.GetChild(0).GetComponent<RawImage>().texture = tex;
            //loadGame3.transform.GetChild(0).GetComponent<RawImage>().texture = dataFoundTex;
            //Set description text to saved date and time
            loadGame3.transform.GetChild(2).GetComponent<Text>().text = "Play Time: " + load3.playTime + "\n" + "Date: " + load3.playDate;
        }
        else
        {
            tex = new Texture2D(2, 2);
            //No existing Player Data, use defaults
            loadGame3.transform.GetChild(0).GetComponent<RawImage>().texture = dataErrorTex;
            loadGame3.transform.GetChild(2).GetComponent<Text>().text = "Play Time: N/A" + "\n" + "Date: N/A";
        }
    }

    public void OptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
        mainMenu.gameObject.SetActive(false);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void NewGame()
    {
        PlayerPrefs.SetInt("NewGame", 1);
        player.saveName = saveGameName;
        player.NewGame();

        
        inMenu = false;
    }

    public void LoadGame()
    {
        Debug.Log("Loading... " + saveGameName);
        player.saveName = saveGameName;
        player.LoadGame();

        //playerObject.transform.position = player.position;

        inMenu = false;
    }

    public void SelectSaveGame(string saveGame)
    {
        saveGameName = saveGame;
    }

    
}
