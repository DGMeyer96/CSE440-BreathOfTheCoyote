using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartupLoader : MonoBehaviour
{
    public Slider loadingBar;
    public Text progressText;

    private void Start()
    {
        //Begin loading the main scene
        LoadLevel(1);
    }

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadLevelAsynchronously(sceneIndex));
    }

    IEnumerator LoadLevelAsynchronously(int sceneIndex)
    {
        AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneIndex);

        while(!loadOperation.isDone)
        {
            //Scene loading has 2 phases.  The first phase is 0 -> 0.9 so we need to clamp the value from 0 -> 1
            //This will ensure the loading bar reflects 0 -> 100% accurately
            //Last 0.1 is simply switching the scene and removing old one (fast and doesn't need to be shown). 
            float loadProgress = Mathf.Clamp01(loadOperation.progress / .9f);

            loadingBar.value = loadProgress;
            progressText.text = (loadProgress * 100f) + "%";

            yield return null;
        }
    }
}
