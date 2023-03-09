using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    GameObject player;
    NavMeshAgent _navMeshAgent;

    // Start is called before the first frame update
    void Start()
    {
        // _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = player.GetComponent<NavMeshAgent>();    // this is the player
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // FIRST, check if the name of self... like gemeObject.name??
            // if it's Door (6), then load next scene, OTHERWISE< teleport
            if (gameObject.name != "Door (6)") {
                // if the gameObject.tag = Wrong tag... telepport... wait 3 sec... teleport to room1
                _navMeshAgent.Warp(teleportTarget.transform.position);
            }
        }


    }




}
