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
    float chaserSpeed;
    public bool isStopped;
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }


    void Update()
    {
        keyTaken = _gameManager.getKeys();
        print(keyTaken);
        StartCoroutine(ChasePlayer());
    }

    IEnumerator ChasePlayer() {
        if (true) {
            if (keyTaken % 2 == 1) {
                _navMeshAgent.isStopped = false;
                yield return new WaitForSeconds(1f);
                _navMeshAgent.destination = player.transform.position;
            } else {
                _navMeshAgent.isStopped = true;
                _navMeshAgent.ResetPath();
            }
        }
    }


}
