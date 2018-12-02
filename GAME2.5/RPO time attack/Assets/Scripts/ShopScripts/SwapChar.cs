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

    public Button buyBtn;
    public Button chooseBtn;

    bool lock1 = false; //za 3. characterja (SE NI UPORABLJENO)
    bool lock2 = false; //za 2. characterja

    private void Start()
    {
        charactersNum = characters.Length; //dobi stevilo characterjev
        price.text = char1Price.ToString() + " €";


        if (PlayerPrefs.GetInt("stUnicenihTarc") < 10) // dokler ne unici 10 tarc ima nekaj zaklenjeno
        {
            lock1 = true;
        }
        if (PlayerPrefs.GetInt("stevecOdigranihLevelov") < 5) // dokler ne odigra 5 iger ima nekaj zaklenjeno
        {
            lock2 = true;
        }
    }

    private void Update()
    {
        if (currentCharacter==0)
        {
            this.GetComponent<Image>().color = new Color32(171, 192, 192, 70);
            price.text = "";
        }
        else if (currentCharacter==1)
        {
            if (PlayerPrefs.GetInt("money")<char2Price){ //ce ni dovolj denarja je cena rdece barve
                price.text = char2Price.ToString() + " €";
                price.color = Color.red;
            }
            else
            {
                price.text = char2Price.ToString() + " €";
            }

            if (lock2 == true) // ce je zaklenjen
            {
                this.GetComponent<Image>().color = new Color32(176, 32, 38, 137); //ce je zaklenjen
            }
            else
            {
                this.GetComponent<Image>().color = new Color32(171, 192, 192, 70); //ce je odklenjen
            }
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
