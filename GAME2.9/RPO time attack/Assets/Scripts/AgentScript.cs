using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{

    private NavMeshAgent agent;
    public GameObject player;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("POZICIJA: "+player.transform.position);
    }

    void Update()
    {
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Ray ray = new Ray(player.transform.position, new Vector3(0.0f, 0.0f, 1.0f));

          /*  Debug.Log("POZICIJA PLayerja: " + player.transform.position);
            Debug.Log("MOUSE CLICK: " + Input.mousePosition);
            Debug.Log("RAY: " + ray);
          */
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.tag == "Floor")
                {
                    agent.SetDestination(hit.point);
                }
            }
    }
}
