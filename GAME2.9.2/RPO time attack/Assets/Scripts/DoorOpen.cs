using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpen : MonoBehaviour
{

    // Use this for initialization
    public GameObject player;
    public Animator animator;
    public bool doorsopen = false;
    private bool keystatus;

    public GameObject stopWatch;
    private SceneTransition trascene;
    private GameObject stransitioner;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        keystatus = player.GetComponent<PlayerManeger>().keyobtained;
        stransitioner = GameObject.FindWithTag("ScenTrans");

    }

    // Update is called once per frame
    void Update()
    {
        keystatus = player.GetComponent<PlayerManeger>().keyobtained;
    }
    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger
    {

        if (other.CompareTag("Player") && doorsopen==false && keystatus==true)
        {
            Debug.Log("Doors are open");
            animator.SetBool("isOpen", true);
            doorsopen = true;
            //asassssssss
            float finalTime = stopWatch.GetComponent<Timer>().t;

            Debug.Log("best time: " + finalTime);

            if (PlayerPrefs.GetInt("stevecOdigranihLevelov") == 1) // ce igramo komaj prvo igro se avtomatsko shrani neš čas igranja
            {
                PlayerPrefs.SetFloat("najboljsiCas", finalTime);
            }
            else // ce smo igro ze veckrat igrali pa se shrani najboljsi cas
            {
                if (finalTime < PlayerPrefs.GetFloat("najboljsiCas"))
                {
                    PlayerPrefs.SetFloat("najboljsiCas", finalTime); //shrani najboljsi cas
                }
            }

            stransitioner.GetComponent<SceneTransition>().TransitionToScene(0);
        }

    }
}
