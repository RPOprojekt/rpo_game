using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapGun : MonoBehaviour {


    public int currentGun = 0;
    public Transform[] guns;

    int gunNum = 1;

    public Text price5;
    public Text price10;

    public int gun1_5 = 2;
    public int gun2_5 = 5;
    public int gun1_10 = 5;
    public int gun2_10 = 8;

    public Button buy5Btn;
    public Button buy10Btn;

    bool lock3 = false; // za gun2

    private void Start()
    {
        gunNum = guns.Length;

        price5.text = gun1_5.ToString()+" €";
        price10.text = gun1_10.ToString() + " €";

        if (PlayerPrefs.GetFloat("najboljsiCas")>20)
        {
            lock3 = true;
        }
    }

    private void Update()
    {
        if (currentGun==0)
        {

            if (PlayerPrefs.GetInt("money") < gun1_5) //ni dovolj denarja -> cena z rdeco barvo
            {
                price5.text = gun1_5.ToString() + " €";
                price5.color = Color.red;
            }
            else
            {
                price5.text = gun1_5.ToString() + " €";
                price5.color = new Color32(17, 245, 29, 255);
            }

            if (PlayerPrefs.GetInt("money") < gun1_10) //ni dovolj denarja -> cena z rdeco barvo
            {
                price10.text = gun1_10.ToString() + " €";
                price10.color = Color.red;
            }
            else
            {
                price10.text = gun1_10.ToString() + " €";
                price10.color = new Color32(17, 245, 29, 255);
            }

            this.GetComponent<Image>().color = new Color32(171, 192, 192, 70);
            buy5Btn.interactable = true;
            buy10Btn.interactable = true;
        }
        else if (currentGun==1)
        {
            if (PlayerPrefs.GetInt("money") < gun2_5) //ni dovolj denarja -> cena z rdeco barvo
            {
                price5.text = gun2_5.ToString() + " €";
                price5.color = Color.red;
            }
            else
            {
                price5.text = gun2_5.ToString() + " €";
                price5.color = new Color32(17, 245, 29, 255);
            }

            if (PlayerPrefs.GetInt("money") < gun2_10) //ni dovolj denarja -> cena z rdeco barvo
            {
                price10.text = gun2_10.ToString() + " €";
                price10.color = Color.red;
            }
            else
            {
                price10.text = gun2_10.ToString() + " €";
                price10.color = new Color32(17, 245, 29, 255);
            }

            if (lock3 == true) // zaklenjeno
            {
                this.GetComponent<Image>().color = new Color32(176, 32, 38, 137); //ce je zaklenjen
                buy5Btn.interactable = false; //dissable btn
                buy10Btn.interactable = false; //dissable btn
            }
            else
            {
                this.GetComponent<Image>().color = new Color32(171, 192, 192, 70);
                buy5Btn.interactable = true; 
                buy10Btn.interactable = true;
            }
        }
    }

    public void SwapCharLeft() //povezano z gumbom CharLeftBtn
    {
        if (currentGun == 0)
        {
            currentGun = gunNum - 1; //gre na zadnjega
        }
        else
        {
            currentGun = currentGun - 1; //eno levo
        }

        SwitchCharImg(currentGun);
    }
    public void SwapCharRight() //povezano z gumbom CharRightBtn
    {
        if (currentGun == gunNum - 1)
        {
            currentGun = 0; //gre na prvega
        }
        else
        {
            currentGun = currentGun + 1; //eno desno
        }

        SwitchCharImg(currentGun);
    }

    void SwitchCharImg(int index)
    {
        for (int i = 0; i < gunNum; i++)
        {
            if (i == index)
            {
                guns[i].gameObject.SetActive(true); //pokazi characterja
            }
            else
            {
                guns[i].gameObject.SetActive(false); //skrij characterja
            }
        }
    }
}
