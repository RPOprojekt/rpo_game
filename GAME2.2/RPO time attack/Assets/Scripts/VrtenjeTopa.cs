using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrtenjeTopa : MonoBehaviour {

    int stevecStrelov = 0;
    int steviloStrelov_reload;

    public MoveBullet bullet;
    public MoveBullet oldbullet;
    public Transform firePoint; //zacetna pozicija metka

    public GameObject player;
    int gun;

    public GameObject gun2;
    public GameObject gun3;

    void Update () {

        int metki2 = gun2.GetComponent<StMetkov>().numBullets; //dobi skripto StMetkov (za gun2)
        int metki3 = gun3.GetComponent<StMetkov>().numBullets; //dobi skripto StMetkov (za gun3)

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

        Rect bounds = new Rect(0, 0, Screen.width/(3.5f), Screen.height/3); // kliki za obračanje pištole in streljanja se zaznavajo le zunaj tega lika
       

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

                if (gun == 1 && metki2 > 0) //ko imaš metke pri gun2 -> metki so numBulets(pobrani v igri)+bullets2(kupljeni)
                {
                    metki2--; //zmanjsaj stevilo metkov (gun2)
                    gun2.GetComponent<StMetkov>().numBullets--;
                    if (GetComponentInChildren<Animator>().GetBool("Reload") == false && GetComponentInChildren<Animator>().GetBool("Shot") == true)
                    {
                        Instantiate(oldbullet, firePoint.position, firePoint.rotation);
                    }
                }

                if (gun == 1 && metki2 == 0) // ko ti zmanjka metkov pri gun2
                {
                    Debug.Log("Pri tej puski ni vec metkov!");
                    GetComponentInChildren<Animator>().SetBool("Shot", false); //konec animacije strela
                    GetComponentInChildren<Animator>().SetBool("Reload", false); //konec strela
                }

                if (gun == 2 && metki3 > 0) //ko imaš metke pri gun3
                {
                    metki3--; //zmanjsaj stevilo metkov (gun2)
                    gun3.GetComponent<StMetkov>().numBullets--;
                    if (GetComponentInChildren<Animator>().GetBool("Reload") == false && GetComponentInChildren<Animator>().GetBool("Shot") == true)
                    {
                        Instantiate(bullet, firePoint.position, firePoint.rotation);
                    }
                }

                if (gun == 2 && metki3 == 0) // ko ti zmanjka metkov pri gun3
                {
                    Debug.Log("Pri tej puski ni vec metkov!");
                    GetComponentInChildren<Animator>().SetBool("Shot", false); //konec animacije strela
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
