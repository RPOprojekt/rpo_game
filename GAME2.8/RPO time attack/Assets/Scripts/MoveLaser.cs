using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLaser : MonoBehaviour {

    public float speed;
    private static bool dirRight = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dirRight==false) {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else if (dirRight==true) {
            transform.Translate(-Vector2.down * speed * Time.deltaTime);
        }
        
        if (transform.position.x >= 14.49f) {
            dirRight = false;
        }
        if (transform.position.x <= 10.6f) {
            dirRight = true;
        }
        
    }
}
