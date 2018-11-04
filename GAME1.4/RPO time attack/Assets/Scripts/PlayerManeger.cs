using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour {

    int numTargets;

    int numCoinStart;
    int numCoin;
    int colectedCoin;

    private void Start()
    {
        numCoinStart = GameObject.FindGameObjectsWithTag("Coin").Length;
    }

    void Update () {

        numTargets = GameObject.FindGameObjectsWithTag("Tarca").Length;
        numCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        colectedCoin = numCoinStart - numCoin; 

        if (numTargets == 0)
        {
            Debug.Log("Unicil si vse tarce vrata so se odprla");
        }
    }
}
