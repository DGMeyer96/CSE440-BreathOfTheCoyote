using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    public int sceneIndex;
    public string saveGameName;
    /*
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeScene(sceneIndex);
    }
    */
    public void ChangeScene(int sceneNumber)
    {
        //Debug.Log("sceneBuildIndex to load: " + sceneNumber);
        switch(sceneNumber)
        {
            case 0:
                Debug.Log("Loading: Main Menu");
                SceneManager.LoadScene(sceneNumber);
                break;
            case 1:
                Debug.Log("Loading: Load Game");
                SceneManager.LoadScene(sceneNumber);
                break;
            case 2:
                Debug.Log("Loading: Options");
                SceneManager.LoadScene(sceneNumber);
                break;
            case 3:
                Debug.Log("Loading: New Game");
                SceneManager.LoadScene(sceneNumber);
                break;
            default:
                Debug.Log("Invalid scene number");
                break;
        }
        
    }

    public void LoadGame()
    {
        Debug.Log("Loading... " + saveGameName);

        //Load game world then load in player data
        SceneManager.LoadScene(3);
    }

    public void SelectSaveGame(string saveGame)
    {
        saveGameName = saveGame;
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    
}
