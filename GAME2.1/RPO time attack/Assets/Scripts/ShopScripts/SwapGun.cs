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


    private void Start()
    {
        gunNum = guns.Length;

        price5.text = gun1_5.ToString()+" €";
        price10.text = gun1_10.ToString() + " €";
    }

    private void Update()
    {
        if (currentGun==0)
        {
            price5.text = gun1_5.ToString() + " €";
            price10.text = gun1_10.ToString() + " €";
        }
        else if (currentGun==1)
        {
            price5.text = gun2_5.ToString() + " €";
            price10.text = gun2_10.ToString() + " €";
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
