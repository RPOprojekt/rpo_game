using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFollow : MonoBehaviour {

    public GameObject character;

	void Start () {
        this.transform.position = character.transform.position;
	}
	
	void Update () {
        this.transform.position = character.transform.position;
    }
}
