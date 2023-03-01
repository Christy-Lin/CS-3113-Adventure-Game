using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMove : MonoBehaviour
{

    // navmesh
    UnityEngine.AI.NavMeshAgent _navMeshAgent;
    Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        mainCam = Camera.main;  // camera
    }

    // Update is called once per frame
    void Update()
    {
        // input from mouse
        if (Input.GetMouseButtonDown(0)) {
            // if left click
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _navMeshAgent.destination = hit.point;  // go to where clicked
            }
        }
    }
    
    // picking up key
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Key")) {
            // int keyNum = Int32.Parse(other.name.Substring(3));  // name of Key object... Key0,...
            Destroy(other.gameObject); // to pick it up
            // PublicVars.hasKey[keyNum] = true;
        }

        if (other.CompareTag("Rook")) {
            // Destroy(gameObject);
        }
    }

}
