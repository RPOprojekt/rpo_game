using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManeger : MonoBehaviour {

    public int currentWeapon = 0;
    public Transform[] weapons;
    public int numWeapons;

    int numTargets;

    int numCoinStart;
    int numCoin;
    int colectedCoin;

    private void Start()
    {
        numCoinStart = GameObject.FindGameObjectsWithTag("Coin").Length;
        numWeapons = weapons.Length;

        SwitchWeapon(currentWeapon);
    }

    void Update () {

        numTargets = GameObject.FindGameObjectsWithTag("Tarca").Length;
        numCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        colectedCoin = numCoinStart - numCoin; 

        if (numTargets == 0)
        {
            Debug.Log("Unicil si vse tarce vrata so se odprla");
        }

        for(int i=1; i<=numWeapons; i++)
        {
            if (Input.GetKeyDown("" + i)) //ZAENKRAT MAMO MENJEVANJE PISTOL Z STEVILKAMI 1 IN 2 ... POL BOMO NAREDLI NEKI GUMB !!!!!
            {
                currentWeapon = i - 1;

                SwitchWeapon(currentWeapon);
            }
        }
    }

    void SwitchWeapon(int index)
    {
        for (int i=0; i<numWeapons; i++)
        {
            if (i==index)
            {
                weapons[i].gameObject.SetActive(true);
            }
            else
            {
                weapons[i].gameObject.SetActive(false);
            }
        }
    }
   
}
