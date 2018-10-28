using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniciTarco : MonoBehaviour {

    public int stTarc; // ST TARC, KLJUCEV... SI NAREDI V POSEBEJ SKRIPTI (GameManeger)

	// Use this for initialization
	void Start () {
		
	}

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger metka
    {
        if (other.CompareTag("Bullet"))
        {
            Destroy(gameObject); //unici tarco
        }
    }
}
