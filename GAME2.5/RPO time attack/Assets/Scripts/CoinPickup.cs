﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour {

    public AudioSource coinPickup;

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            coinPickup.Play();
        }
    }
}
