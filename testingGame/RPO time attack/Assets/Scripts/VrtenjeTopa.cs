using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrtenjeTopa : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

        //object controller = GameObject.FindGameObjectsWithTag("GameController");

        Rect bounds = new Rect(0, 0, Screen.width/3, Screen.height/3);

        if (Input.GetMouseButtonDown(0) && ! bounds.Contains(Input.mousePosition))
        {
            var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back);
        }

	}
}
