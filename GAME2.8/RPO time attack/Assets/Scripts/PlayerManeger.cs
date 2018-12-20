using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManeger : MonoBehaviour {

    public int currentWeapon = 0;
    public Transform[] weapons; //array za orožja
    public int numWeapons;

    int numTargets;

    int numCoinStart;
    int numCoin;
    public int colectedCoin;
    public int totalCoinSum;
    public bool spawnkey = false;
    public bool keyobtained = false;

    int stUnicenihTarc=0; //za trgovino (unlock ko vse skupaj unicis 10 tarc)
    public GameObject door;

    public Transform[] characters; //array za orožja
    public int numChar;

    private void Start()
    {
        spawnkey = false;
        totalCoinSum = PlayerPrefs.GetInt("money");
        numCoinStart = GameObject.FindGameObjectsWithTag("Coin").Length;
        numWeapons = weapons.Length;

        SwitchWeapon(currentWeapon);

        if (PlayerPrefs.GetInt("player")==0) //prikazi aktivnega playerja
        {
            characters[0].gameObject.SetActive(true);
            characters[1].gameObject.SetActive(false);
        }
        else if (PlayerPrefs.GetInt("player") == 1)
        {
            characters[1].gameObject.SetActive(true);
            characters[0].gameObject.SetActive(false);
        }
    }

    void Update () {

        numTargets = GameObject.FindGameObjectsWithTag("Tarca").Length;
        numCoin = GameObject.FindGameObjectsWithTag("Coin").Length;
        colectedCoin = numCoinStart - numCoin;

        if (numTargets == 0 && spawnkey==false) //vse tarce unicene
        {
            stUnicenihTarc = 2;
            spawnkey = true;
            Debug.Log("Unicil si vse tarce spawnal se je kljuc");
        }
        if (numTargets == 0 && !GameObject.FindGameObjectWithTag("keyspawnpoint") && keyobtained==false) //Kljuc prejet
        {
            keyobtained = true;
            Debug.Log("Pobral si ključ");
        }

    }

    public void ClickChangeGunButton() //Z klikom na gumb menjas orozje
    {
        currentWeapon++;
        if (currentWeapon==numWeapons) // ce je zadnje orozje gre ob naslednjem kliku na prvega(krozna vrsta)
        {
            currentWeapon = 0;
        }
        SwitchWeapon(currentWeapon);
    }

    void SwitchWeapon(int index)
    {
        
        for (int i=0; i<numWeapons; i++)
        {
            if (index != 0 && i == index && weapons[index].GetComponent<StMetkov>().numBullets != 0) //ce imas orozje pri NE-osnovnem orozju
            {
                Debug.Log("Metki");
                weapons[i].gameObject.SetActive(true);
            }
            else if (index == 0 && i == index) //osnovno orozje ... neomejeno st metkov ... vedno lahko das na true
            {
                weapons[i].gameObject.SetActive(true);
            }
            else if(i == index && weapons[index].GetComponent<StMetkov>().numBullets == 0) //ce pri želenem orozju nimas metkov
            {
                Debug.Log("Nimas metkov");
                currentWeapon = 0;
                weapons[0].gameObject.SetActive(true); //obdrzi osnovno orozje
            }
            if(index!=i) //ostale daj na false
            { 
                weapons[i].gameObject.SetActive(false);
            }
        }
    }

    public void ExitGame()
    {
        totalCoinSum = totalCoinSum + colectedCoin; //sesteje kovance ki smo jih imeli z novimi pobranimi
        PlayerPrefs.SetInt("money", totalCoinSum); //sharni money
        for(int i=0; i<numWeapons; i++)
        {
            PlayerPrefs.SetInt("bulets"+weapons[i].name, 0); //na koncu igre so vsi metki 0
        }
        PlayerPrefs.SetInt("stUnicenihTarc", PlayerPrefs.GetInt("stUnicenihTarc")+ stUnicenihTarc); //shranjuje st unicenih tarc do sedaj

        if (door.GetComponent<DoorOpen>().doorsopen == true)
        {
            PlayerPrefs.SetInt("stevecOdigranihLevelov", PlayerPrefs.GetInt("stevecOdigranihLevelov") + 1); //shranjuje st koncanih levelov
        }
        SceneManager.LoadScene("Menu"); //gre v meni
    }

}
