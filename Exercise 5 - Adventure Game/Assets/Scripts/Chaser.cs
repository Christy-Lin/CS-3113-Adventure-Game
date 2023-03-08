using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chaser : MonoBehaviour
{
    NavMeshAgent _navMeshAgent;
    GameObject player;
    GameManager _gameManager;
    int keyTaken;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        
        

        StartCoroutine(ChasePlayer());
    }


    void Update()
    {
        keyTaken = _gameManager.getKeys();
        print(keyTaken);
    }

    IEnumerator ChasePlayer() {
        while (true) {

            // if (keyTaken == 1) {
                yield return new WaitForSeconds(1f);
                _navMeshAgent.destination = player.transform.position;
            // }
        }
    }


}
