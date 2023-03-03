using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    GameManager _gameManager;

    UnityEngine.AI.NavMeshAgent _navMeshAgent;
    Camera mainCam;
    public GameObject puzzleObj;

    bool allowDamage = true;
    float secSinceLastDamage = 0.0f;
    public float allowDamageInterval = 0.5f;

    public int totalKey = 12; // total key count in the level
    int keyTaken = 0; // keys collected by the player

    public AudioClip collectSound; 
    public AudioClip deathSfx;
    AudioSource _audioSource;

    void Start()
    {
        mainCam = Camera.main;
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();

        if (puzzleObj) { //SceneManager.GetActiveScene().name == "puzzleCombination" &&
            //puzzleObj.GetComponent<puzzleCombi>().Start();
        }
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (_gameManager.GetLives() <= 0) {
            //Instantiate(explosion, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(deathSfx);
            Destroy(gameObject);
        }

        // if left click
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hit, 200)) {
                _navMeshAgent.destination = hit.point;  // go to where clicked
            }
        }
    }
    
    private void dmgCheck() {
        if (!allowDamage) {
            secSinceLastDamage += Time.deltaTime;
            
            if (secSinceLastDamage >= allowDamageInterval) {
                allowDamage = true;
                secSinceLastDamage = 0f;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        //picking up key
        if (other.CompareTag("Key")) {
            _audioSource.PlayOneShot(collectSound);
            keyTaken += 1; // adds a key point for the player
            // int keyNum = Int32.Parse(other.name.Substring(3));  // name of Key object... Key0,...
            Destroy(other.gameObject); // to pick it up
            // PublicVars.hasKey[keyNum] = true;
            // keyTaken++; // adds a key point for the player
            if (keyTaken == totalKey) {
                PublicVars.hasKey = true;
            }
        }

        //damage
        if (other.CompareTag("Rook")) {
            _gameManager.LivesDecr(0.5);
            allowDamage = false;
        }

        if (other.CompareTag("Plate")) { 
            puzzleObj.GetComponent<puzzleCombi>().Input(other.gameObject);
            allowDamage = false;
        }
    }

}
