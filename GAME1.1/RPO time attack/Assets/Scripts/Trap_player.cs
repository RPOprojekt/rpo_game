using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_player : MonoBehaviour {

    
    private PlayerMovement playerScript;

    Vector2 startPosition = Vector2.zero;

    private void Start()
    {
        GameObject player = GameObject.FindWithTag("Player");

        startPosition = player.transform.position; //dobi zacetno pozicijo Playerja
        Debug.Log(startPosition);

        playerScript = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger
    {
        if (other.CompareTag("KillTrap"))
        {
            Debug.Log("You got killed");
            transform.position = startPosition; //playerja vrze na zacetno pozicijo
        }

        if (other.CompareTag("SlowTrap"))
        {
            float temp = playerScript.speed;
            Debug.Log("You are slowed down for 5s");
            playerScript.speed = playerScript.speed * 0.3f; //playerja upočasni

            StartCoroutine(Wait(temp)); //pocakaj 5s
        }
    }

    IEnumerator Wait(float temp)
    { 
        yield return new WaitForSeconds(5.0f);

        playerScript.speed = temp;
        Debug.Log("Znova si hiter");
    }
}
