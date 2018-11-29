using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public Animator animator;

    public GameObject player;
    public GameObject gunInChest; //gun ki bo v chestu
    public int stMetkovChest;

    bool openChest = false;

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger
    {
        StMetkov metkiScript = gunInChest.GetComponent<StMetkov>();

        if (other.CompareTag("Player"))
        {
            Debug.Log("Chest open");
            animator.SetBool("Open", true);

            if (openChest == false) //ce se ni odprta
            {
                metkiScript.numBullets = metkiScript.numBullets + stMetkovChest; //pristeje metke iz chesta
                openChest = true;
            }
        }
    }
}