using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GamePlayController : MonoBehaviour {
    public static GamePlayController instance;
    [SerializeField]
    private GameObject pausePanel;
    [SerializeField]
    private GameObject gameOverPanel;
    [SerializeField]
    private GameObject gameWinPanel;
    public bool checkDie=false;
    public static int checkCreateRunsEnemy = 0;
    public void GameWin()
    {
        //gameWinPanel.SetActive(true);
        //Time.timeScale = 0;
        StartCoroutine(timeoutGameWin());
    }
    public void gameHome()
    {
        SceneManager.LoadScene("MainScreen");
    }
    public void GameOverButton()
    {
        StartCoroutine(timeoutGameOver());
    }
     private IEnumerator timeoutGameOver()
     {
        yield return new WaitForSeconds(2.0f);
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
     }

    private IEnumerator timeoutGameWin()
    {
       
        yield return new WaitForSeconds(5.0f);
        gameWinPanel.SetActive(true);
        Time.timeScale = 1;
    }

    public void gameReload()
    {
        SceneManager.LoadScene("ScreenOne");
        Time.timeScale = 1;
    }

    private void Awake()
    {
        Screen.orientation = ScreenOrientation.PortraitUpsideDown;
        MakeInstance();
    }
    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
 
    public void GamePauseButton()
    {       
            pausePanel.SetActive(true);
            Time.timeScale = 0;
    }
    public void GameResumeButton()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
