using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour {

	public void PlayGameBtn(string newGameLevel)
    {
        ScoreScript.eUmNovoJogo = true;
		SceneManager.LoadScene(newGameLevel);		
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

}