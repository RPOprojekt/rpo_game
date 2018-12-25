using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour {

    public float speed;

	void Start () {

	}
	
	void Update () {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}
}
