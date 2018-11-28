using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwapChar : MonoBehaviour {

    public int currentCharacter=0;
    public Transform[] characters;

    int charactersNum = 1;

    public Text price;
    public int char1Price = 0;
    public int char2Price = 5;


    private void Start()
    {
        charactersNum = characters.Length; //dobi stevilo characterjev
        price.text = char1Price.ToString() + " €";
    }

    private void Update()
    {
        if (currentCharacter==0)
        {
            price.text = char1Price.ToString()+" €";
        }
        else if (currentCharacter==1)
        {
            price.text = char2Price.ToString()+" €";
        }
    }

    public void SwapCharLeft() //povezano z gumbom CharLeftBtn
    {
        if (currentCharacter == 0)
        {
            currentCharacter = charactersNum-1; //gre na zadnjega
        }
        else
        {
            currentCharacter = currentCharacter - 1; //eno levo
        }

        SwitchCharImg(currentCharacter);
    }
    public void SwapCharRight() //povezano z gumbom CharRightBtn
    {
        if (currentCharacter == charactersNum-1)
        {
            currentCharacter = 0; //gre na prvega
        }
        else
        {
            currentCharacter = currentCharacter + 1; //eno desno
        }

        SwitchCharImg(currentCharacter);
    }

    void SwitchCharImg(int index)
    {
        for (int i = 0; i < charactersNum; i++)
        {
            if (i == index)
            {
                characters[i].gameObject.SetActive(true); //pokazi characterja
            }
            else
            {
                characters[i].gameObject.SetActive(false); //skrij characterja
            }
        }
    }
}
