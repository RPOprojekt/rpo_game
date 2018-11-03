using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;


	// Use this for initialization
	void Start () {

        offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () { //Late update run after all proces has been updated

        transform.position = player.transform.position + offset; //vsaki frame se kamera premika za playerjem
	}
}
