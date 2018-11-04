using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrtenjeTopa : MonoBehaviour {

    int stevecStrelov = 0;

    public MoveBullet bullet;
    public Transform firePoint; //zacetna pozicija metka

    private void Start()
    {

    }

    void Update () {

        //object controller = GameObject.FindGameObjectsWithTag("GameController");

        Rect bounds = new Rect(0, 0, Screen.width/3, Screen.height/3); // kliki za obračanje pištole se zaznavajo le zunaj tega lika

        if (Input.GetMouseButtonDown(0) && ! bounds.Contains(Input.mousePosition))
        {
            var direction = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
            var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.back); //pistola se obrne

            if (Input.GetMouseButtonDown(0))
            {
                GetComponentInChildren<Animator>().SetBool("Shot", true); //animacija strela
                StartCoroutine(Wait(stevecStrelov));

                stevecStrelov++;

                if (stevecStrelov > 9) {
                    GetComponentInChildren<Animator>().SetBool("Reload", true); //animacija reload gun
                    StartCoroutine(Wait(stevecStrelov));
                    stevecStrelov = 0;
                }

                //ustvari metek
                if (GetComponentInChildren<Animator>().GetBool("Reload") == false && GetComponentInChildren<Animator>().GetBool("Shot") == true)
                {
                    Instantiate(bullet, firePoint.position, firePoint.rotation);
                }

            }
        }
	}

    IEnumerator Wait(int stevec)
    {
        if (stevecStrelov < 10)
        {
            yield return new WaitForSeconds(0.1f);
            GetComponentInChildren<Animator>().SetBool("Shot", false); //konec strela
        }
        else
        {
            GetComponentInChildren<Animator>().SetBool("Shot", false); //dokler se reloada ne more streljat
            yield return new WaitForSeconds(0.25f);
            GetComponentInChildren<Animator>().SetBool("Reload", false); //konec reloada
        }
    }
}
