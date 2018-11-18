using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrtenjeTopa : MonoBehaviour {

    int stevecStrelov = 0;
    int steviloStrelov_reload;

    public MoveBullet bullet;
    public Transform firePoint; //zacetna pozicija metka

    public GameObject player;
    int gun;

    public GameObject gun2;

    private void Start()
    {
       
    }

    void Update () {

        StMetkov metkiScript = gun2.GetComponent<StMetkov>(); //dobi skripto StMetkov (za gun2)

        PlayerManeger maneger = player.GetComponent<PlayerManeger>(); //dobi class PlayerManeger
        gun = maneger.currentWeapon; //dobi izbrano pusko

        if (gun == 0)
        {
            steviloStrelov_reload = 10;
        }
        if (gun == 1)
        {
            steviloStrelov_reload = 5;
        }

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

                if (stevecStrelov > steviloStrelov_reload) {
                    GetComponentInChildren<Animator>().SetBool("Reload", true); //animacija reload gun
                    StartCoroutine(Wait(stevecStrelov));
                    stevecStrelov = 0;
                }

                //ustvari metek
                if (gun == 0)
                {
                    if (GetComponentInChildren<Animator>().GetBool("Reload") == false && GetComponentInChildren<Animator>().GetBool("Shot") == true)
                    {
                        Instantiate(bullet, firePoint.position, firePoint.rotation);
                    }
                }

                if (gun == 1 && metkiScript.numBullets > 0) //ko imaš metke pri gun2
                {
                    metkiScript.numBullets--; //zmanjsaj stevilo metkov (gun2)
                    if (GetComponentInChildren<Animator>().GetBool("Reload") == false && GetComponentInChildren<Animator>().GetBool("Shot") == true)
                    {
                        Instantiate(bullet, firePoint.position, firePoint.rotation);
                    }
                }

                if (gun == 1 && metkiScript.numBullets == 0) // ko ti zmanjka metkov pri gun2
                {
                    Debug.Log("Pri tej puski ni vec metkov!");
                    GetComponentInChildren<Animator>().SetBool("Shot", false); //konec strela
                    GetComponentInChildren<Animator>().SetBool("Reload", false); //konec strela
                }

            }
        }
	}

    IEnumerator Wait(int stevec)
    {
        if (stevecStrelov < steviloStrelov_reload)
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
