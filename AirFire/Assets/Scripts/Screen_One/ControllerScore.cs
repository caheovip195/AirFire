using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerScore : MonoBehaviour {
    public static ControllerScore instance;
    public static int scoreEnemysRun = 0;
    private int score;
	// Use this for initialization
	void Start () {
        instance = this;
        //get value to cache
        score = PlayerPrefs.GetInt("save_score",0);
        gameObject.GetComponent<Text>().text =score+"";
        PlayerPrefs.SetInt("save_score",0);
    }
	
	// Update is called once per frame
	public void AddScore(int scoreadd)
    {
        score += scoreadd;
        //save value from cache
        PlayerPrefs.SetInt("save_score", score);
        gameObject.GetComponent<Text>().text =score+"";
    }
}
