using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Text recordTime;

	// Use this for initialization
	void Start () {
        float t = PlayerPrefs.GetFloat("najboljsiCas");

        string minutes = ((int)t / 60).ToString();
        string seconds = ((t % 60).ToString("f0"));

        recordTime.text = "RECORD TIME: " + minutes + ":" + seconds;
    }
}
