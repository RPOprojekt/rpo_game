using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    Transform _destination;

    NavMeshAgent navMashAgent;

    public float speed;
    bool dirRight = false;
    bool zacetnoGibanje = true;

    public GameObject player;

    private void Start()
    {
        navMashAgent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (zacetnoGibanje == true) {
            if (dirRight == false)
            {
                transform.Translate(Vector2.left * speed * Time.deltaTime);
            }
            else if (dirRight == true)
            {
                transform.Translate(-Vector2.left * speed * Time.deltaTime);
            }

            if (transform.position.x >= 9.0f)
            {
                dirRight = false;
            }
            if (transform.position.x <= 3.0f)
            {
                dirRight = true;
            }

            if (Math.Sqrt((Math.Pow((player.transform.position.x - transform.position.x),2)) + Math.Pow((player.transform.position.y -transform.position.y),2))  <= 2)
            {
                zacetnoGibanje = false;
            }
        }
        else{
            //OBRACANJE PROTI PLAYERJU
            Vector3 norTar = (player.transform.position- transform.position).normalized;
            float angle = Mathf.Atan2(norTar.y, norTar.x) * Mathf.Rad2Deg;
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, 0, angle - 270);
            transform.rotation = rotation;

            //PREMIKANJE ZA PLAYERJOM
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
