using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StMetkov : MonoBehaviour {

    public int numBullets;

	public void Start () {
        string name = this.name;
        numBullets = numBullets + PlayerPrefs.GetInt("bulets"+name)-1; //dobi metke kupljenje v trgovini

        Debug.Log("Dobil sem metke: "+ numBullets);
    }
}
