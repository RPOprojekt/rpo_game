using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDestroy : MonoBehaviour {

    private PlayerMovement playerScript;    //uporabim da lahko playera vrnem na začetek
    

    private Trap_player getstartpos;    //uporabim da dobim začetno pozicijo
    Vector2 startPosition = Vector2.zero;   //shranim začetno pozicijo
    private GameObject visiontrapper;
    // Use this for initialization
    void Start()
    {
        visiontrapper = GameObject.FindWithTag("VisionTrap");

        GameObject player = GameObject.FindWithTag("Player");   //iz gameobjecta player
        playerScript = player.GetComponent<PlayerMovement>();   //vzamem inicializiram playermovement script
        getstartpos = player.GetComponent<Trap_player>();       // in trap_player script
        startPosition = getstartpos.startPosition;  //Startno pozicijo prenesem iz trapplayer

        StartCoroutine(Wait()); //če se arrow ne zaleti v nič se uniči po 3 sekundah
    }

    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger metka
    {
        if (other.CompareTag("Player"))
        {   //če se zaleti v playerja ga postavi na začetek
            //playerScript.transform.position = startPosition; //vrne playerja na zacetek
            visiontrapper.GetComponent<visiontrapscript>().VisionShrink();
        }

        if (!(other.CompareTag("BowTrigger") || other.CompareTag("BowTrigger2"))) {  //Ko potuje prek tripwire se ne uniči
            Destroy(gameObject); //arrow se unici ce se dotakne drugega coliderja
        }
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f); //arrow se uniči po 3sekunadah
        Destroy(gameObject);
    }
}
