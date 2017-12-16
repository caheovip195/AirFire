﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MainController : MonoBehaviour {

    public static MainController instance;

    private void Awake()
    {
        MakeInstance();
    }
    private void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void gameStart()
    {
        SceneManager.LoadScene("ScreenOne");
        Time.timeScale = 1;
       
    }
    public void gameSetting()
    {

    }
    public void gameShare()
    {

    }
    public void gameRate()
    {
    
    }
}