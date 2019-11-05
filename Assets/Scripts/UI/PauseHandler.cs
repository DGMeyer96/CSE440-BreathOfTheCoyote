using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseHandler : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;
    public Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Debug.Log("Pausing game");

            if(gamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        EnableControl();
        gamePaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        DisableControl();
        gamePaused = true;
    }

    public void MainMenu()
    {
        Debug.Log("Loading: Main Menu");
        player.SaveGame();
        PlayerPrefs.SetInt("LevelToLoad", 1);
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        PlayerPrefs.SetInt("LevelToLoad", 1);
        Application.Quit();
    }

    public bool GetGamePaused()
    {
        return gamePaused;
    }

    private void DisableControl()
    {
        //player.GetComponent<CompassHandler>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        //player.GetComponentInChildren<eyelook>().enabled = false;
    }

    private void EnableControl()
    {
        player.GetComponent<PlayerController>().enabled = true;
        //player.GetComponentInChildren<eyelook>().enabled = true;
    }
}
