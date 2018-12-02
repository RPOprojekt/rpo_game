using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKeyScript : MonoBehaviour
{

    // Use this for initialization
    private bool spawnkeyinfo;
    public GameObject keyy;
    GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawnkeyinfo = player.GetComponent<PlayerManeger>().spawnkey;
        keyy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        spawnkeyinfo = player.GetComponent<PlayerManeger>().spawnkey;
        if (spawnkeyinfo == true)
        {
            keyy.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger
    {
        if (other.CompareTag("Player") && spawnkeyinfo == true)
        {
            Destroy(gameObject);
        }
    }
}

