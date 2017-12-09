using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerScore : MonoBehaviour {
    public static ControllerScore instance;
    private int score;
	// Use this for initialization
	void Start () {
        instance = this;
        score = PlayerPrefs.GetInt("save_score",0);
        gameObject.GetComponent<Text>().text = "Score : " + score;
	}
	
	// Update is called once per frame
	public void AddScore(int scoreadd)
    {
        score += scoreadd;
        PlayerPrefs.SetInt("save_score", score);
        gameObject.GetComponent<Text>().text = "Score : " + score;
    }
}
