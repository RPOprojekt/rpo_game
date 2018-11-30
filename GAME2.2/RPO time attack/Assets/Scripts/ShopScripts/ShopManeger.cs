using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ShopManeger : MonoBehaviour {

    public int money;
    public Text moneyText;

    public GameObject characterBG;
    public GameObject gunBG;
    int currentChar;
    int currentGun;

    int bulletsGun1;
    int bulletsGun2;

    public Button buyBtn;
    public Button chooseBtn;

    void Start () {
        money = PlayerPrefs.GetInt("money"); //PlayerPreferences stores data when switching between scenes

        bulletsGun1 = 0;
        bulletsGun2 = 0;        
    }
	
	void Update () {
        moneyText.text = "Money: " + money.ToString() + "€";

        currentChar = characterBG.GetComponent<SwapChar>().currentCharacter;
        currentGun = gunBG.GetComponent<SwapGun>().currentGun;
    }

    public void BuyCharacter()
    {
        if (currentChar==0 && money >= characterBG.GetComponent<SwapChar>().char1Price)//kupi prvega
        {
            money = money - characterBG.GetComponent<SwapChar>().char1Price;
        }
        else if (currentChar == 0 && money < characterBG.GetComponent<SwapChar>().char1Price)//Ni dovolj denarja
        {
            Debug.Log("Ni dovolj denarja");
        }
        else if (currentChar==1 && money >= characterBG.GetComponent<SwapChar>().char2Price)//kupi drugega
        {
            money = money - characterBG.GetComponent<SwapChar>().char2Price;
            chooseBtn.interactable = true; //enable btn

        }
        else if (currentChar == 1 && money < characterBG.GetComponent<SwapChar>().char2Price)//Ni dovolj denarja
        {
            Debug.Log("Ni dovolj denarja");
        }
    }
    public void ChoseCharacter()
    {
        if (currentChar == 0)//izberi prvega za igranje
        {
           
        }
        else if (currentChar == 1)//izberi drugega za igranje
        {
            
        }
    }
    public void Buy5Bullets()
    {
        if (currentGun == 0 && money>=gunBG.GetComponent<SwapGun>().gun1_5)//kupi prvega 5 metkov
        {
            money = money - gunBG.GetComponent<SwapGun>().gun1_5;
            bulletsGun1 = bulletsGun1 + 5;
        }
        else if (currentGun == 0 && money < gunBG.GetComponent<SwapGun>().gun1_5) //Ni dovolj denarja
        {
            Debug.Log("Ni dovolj denarja.");
        }
        else if (currentGun == 1 && money >= gunBG.GetComponent<SwapGun>().gun2_5)//kupi drugega 5 moetkov
        {
            money = money - gunBG.GetComponent<SwapGun>().gun2_5;
            bulletsGun2 = bulletsGun2 + 5;
        }
        else if (currentGun == 1 && money < gunBG.GetComponent<SwapGun>().gun2_5)//Ni dovolj denarja
        {
            Debug.Log("Ni dovolj denarja.");
        }
    }
    public void Buy10Bullets()
    {
        if (currentGun == 0 && money >= gunBG.GetComponent<SwapGun>().gun1_10)//kupi prvega 10 metkov
        {
            money = money - gunBG.GetComponent<SwapGun>().gun1_10;
            bulletsGun1 = bulletsGun1 + 10;
        }
        else if (currentGun == 0 && money < gunBG.GetComponent<SwapGun>().gun1_10)//Ni dovolj denarja
        {
            Debug.Log("Ni dovolj denarja.");
        }
        else if (currentGun == 1 && money >= gunBG.GetComponent<SwapGun>().gun2_10)//kupi drugega 10 metkov
        {
            money = money - gunBG.GetComponent<SwapGun>().gun2_10;
            bulletsGun2 = bulletsGun2 + 10;
        }
        else if (currentGun == 0 && money < gunBG.GetComponent<SwapGun>().gun2_10)//Ni dovolj denarja
        {
            Debug.Log("Ni dovolj denarja.");
        }
    }

    public void ExitShop()
    {
        PlayerPrefs.SetInt("money", money); //sharni money
        PlayerPrefs.SetInt("buletsGun1", bulletsGun1); //sharni metke za gun1
        PlayerPrefs.SetInt("buletsGun2", bulletsGun2); //sharni metke za gun2
        PlayerPrefs.SetInt("buletsGun3", 0); //sharni metke za gun3
        Debug.Log("Metki: "+PlayerPrefs.GetInt("buletsGun2"));
        SceneManager.LoadScene("Menu"); //gre v meni
    }
}
