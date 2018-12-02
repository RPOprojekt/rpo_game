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

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        keystatus = player.GetComponent<PlayerManeger>().keyobtained;
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
            StartCoroutine(WaitResetTrap());
        }

    }

    IEnumerator WaitResetTrap()
    {
        yield return new WaitForSeconds(0.5f);
        player.GetComponent<PlayerManeger>().ExitGame();
    }
}
