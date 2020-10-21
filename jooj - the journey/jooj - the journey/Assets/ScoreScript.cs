using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public static int scoreValue = 0;
	Text score;
    public static bool eUmNovoJogo = true;

	// Use this for initialization
	void Start()
    {
		score = GetComponent<Text> ();

        if (!eUmNovoJogo) 
        {
            scoreValue = PlayerPrefs.GetInt("score");
        }
        else
        {
            scoreValue = 0;
        }

        Debug.Log(PlayerPrefs.GetInt("score"));
	}
	
	// Update is called once per frame
	void Update()
    {
		score.text = "Score: " + scoreValue;
        PlayerPrefs.SetInt("score", scoreValue);
	}
}
