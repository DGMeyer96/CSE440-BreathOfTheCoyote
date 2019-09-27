using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public int sceneIndex;
    public int gameLoadIndex;
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
                break;
            case 1:
                Debug.Log("Loading: Load Game");
                break;
            case 2:
                Debug.Log("Loading: Options");
                break;
            case 3:
                Debug.Log("Loading: New Game");
                break;
            default:
                Debug.Log("Invalid scene number");
                break;
        }
        SceneManager.LoadScene(sceneNumber);
    }

    public void ExitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

    public void LoadGame()
    {
        Debug.Log("Loading...");
    }
}
