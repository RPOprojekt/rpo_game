using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowTrapShot : MonoBehaviour {

    private Trap_player bowscript;

    public MoveBullet arrow;
    public Transform firePoint;
    public Transform firePoint2;
    public int nrOfArrows;

    private bool bowreload = false;
    private bool bowreload2 = false;
    // Use this for initialization
    void Start () {

        GameObject player = GameObject.FindWithTag("Player");
        bowscript = player.GetComponent<Trap_player>();
    }
	
	// Update is called once per frame
	void Update () {

        if (bowscript.shootarrow == true && bowreload == false && nrOfArrows == 2) 
        {
            Debug.Log("You stepped in bow trap.");
            Instantiate(arrow, firePoint.position, firePoint.rotation);
            Instantiate(arrow, firePoint2.position, firePoint2.rotation);

            bowscript.shootarrow = false;
            StartCoroutine(Waitbow());  //počaka da se lok znova napne
        }

        if (bowscript.shootarrow2 == true && bowreload2 == false && nrOfArrows == 1)
        {
            Debug.Log("You stepped in bow trap.");
            Instantiate(arrow, firePoint.position, firePoint.rotation);

            bowscript.shootarrow2 = false;
            StartCoroutine(Waitbow2());  //počaka da se lok znova napne

        }
    }

    IEnumerator Waitbow()
    {
        yield return new WaitForSeconds(1.6f);
        bowscript.bowreload = false; //lok je znova napet
    }

    IEnumerator Waitbow2()
    {
        yield return new WaitForSeconds(1.6f);
        bowscript.bowreload2 = false; //lok je znova napet
    }

}
