﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	
    public void QuitGame()
    {
        Application.Quit();
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("Shop");
    }

}
