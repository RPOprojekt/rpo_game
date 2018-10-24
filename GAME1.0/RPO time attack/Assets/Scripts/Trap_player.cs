using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap_player : MonoBehaviour {

    bool killed = false;

    Vector2 startPosition = Vector2.zero;

    private void Start()
    {
        startPosition = GameObject.FindGameObjectWithTag("Player").transform.position; //dobi zacetno pozicijo Playerja
        Debug.Log(startPosition);
    }

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger
    {
        if (other.CompareTag("KillTrap"))
        {
            Debug.Log("You got killed");
            killed = true;

            transform.position = startPosition; //playerja vrze na zacetno pozicijo
        }

        if (other.CompareTag("SlowTrap"))
        {
            Debug.Log("You are slowed down for 5s");
        }
    }
}
