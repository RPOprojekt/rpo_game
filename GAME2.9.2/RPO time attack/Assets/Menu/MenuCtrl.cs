using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuCtrl : MonoBehaviour {
    /*
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
	*/

    private GameObject stransitioner;//transition v menu

    private void Start()
    {
        stransitioner = GameObject.FindWithTag("ScenTrans");
    }

    public void LoadScene(int sceneindex)
    {
        stransitioner.GetComponent<SceneTransition>().TransitionToScene(sceneindex); //gre v meni
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
