using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    GameObject player;
    NavMeshAgent _navMeshAgent;
    Vector3 starting_point;

    // Start is called before the first frame update
    void Start()
    {
        // _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = player.GetComponent<NavMeshAgent>();    // this is the player
        starting_point = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            // if it's Door (6), then Door.cs script will be used for next level
            // otherwise: teleport
            if (gameObject.name != "Door (6)") {
                // if teleporting to the room where you die (Teleport5), coroutine
                if (teleportTarget.name == "Teleport5") {
                    StartCoroutine(WrongDoor());
                }
                // otherwise just teleport
                else {
                    _navMeshAgent.Warp(teleportTarget.transform.position);
                }
            }
        }


    }

    IEnumerator WrongDoor() {
        // teleport, wait, teleport back
        _navMeshAgent.Warp(teleportTarget.transform.position);
        yield return new WaitForSeconds(3);
        _navMeshAgent.Warp(starting_point);
    }




}
