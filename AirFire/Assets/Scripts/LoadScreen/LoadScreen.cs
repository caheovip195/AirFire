using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(TimerLoad(ControllerScrene.screen));
	}
   IEnumerator TimerLoad(int number_scene)
    {
        yield return new WaitForSeconds(7.0f);
        switch (number_scene)
        {
            case 1: {
                    SceneManager.LoadScene("ScreenOne");
                    Time.timeScale = 1;
                } break;
            case 2: SceneManager.LoadScene("ScreenTwo"); break;
        }
    }
}
