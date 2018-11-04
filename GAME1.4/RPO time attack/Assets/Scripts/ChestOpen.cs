using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestOpen : MonoBehaviour
{
    public Animator animator;

    
    void Start()
    {

    }

   
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Chest open");
            animator.SetBool("Open", true);
        }
    }
}