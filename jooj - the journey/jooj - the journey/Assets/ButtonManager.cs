using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

    public void PlayGameBtn(string LoadingScene1)
    {
        ScoreScript.eUmNovoJogo = true;
        SceneManager.LoadScene(LoadingScene1);
    }

    public void LoadGameBtn(string newGameLevel)
    {
        ScoreScript.eUmNovoJogo = false;
        SceneManager.LoadScene(newGameLevel);
    }

    public void OptionsBtn(string MainMenuScreen)
    {
        SceneManager.LoadScene(MainMenuScreen);
    }


    public void ExitBtn(string MainMenuScreen)
    {
        Application.Quit();
    }

    void OnTriggerEnter()
    {
        Application.LoadLevel(4);
    }

    // Update is called once per frame
    void Update()
    {
        OnGUI();
    }


    void OnGUI()
    {

        if (Event.current.Equals(Event.KeyboardEvent("enter")) && SceneManager.GetActiveScene().name.Equals("LoadingScene1"))
            StartCoroutine(WaitToLoad(0, 2));
        
        else if (Event.current.Equals(Event.KeyboardEvent("escape")) && SceneManager.GetActiveScene().name.Equals("MainGameScene"))
            StartCoroutine(WaitToLoad(0, 3));

        else if (SceneManager.GetActiveScene().name.Equals("LoadBackMenu"))
            StartCoroutine(WaitToLoad(5, 0));
        
        else if (SceneManager.GetActiveScene().name.Equals("LoadEarthScene"))
            StartCoroutine(WaitToLoad(5, 5));

    }

    IEnumerator WaitToLoad(int seconds, int sceneIndex)
    {
        yield return new WaitForSeconds(seconds);

        SceneManager.LoadScene(sceneIndex);
    }


}