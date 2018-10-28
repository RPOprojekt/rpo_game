using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Wait());
    }

    void Update()
    {
    
    }

    private void OnTriggerEnter2D(Collider2D other) //ce se sprozi trigger metka
    {
        Destroy(gameObject); //metek se unici ce se dotakne drugega coliderja
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f); //metek se uniči po 3sekunadah
        Destroy(gameObject);
    }
}
