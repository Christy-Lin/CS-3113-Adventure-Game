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

    public AudioClip collectSound, deathSfx, hitSound; 
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
            _gameManager.GetComponent<GameManager>().KeyIncr();
            Destroy(other.gameObject);
        }

        //damage
        if (other.CompareTag("Rook")) {
            _gameManager.LivesDecr(1);
            allowDamage = false;
        }

        if (other.CompareTag("missile")) {
            _audioSource.PlayOneShot(hitSound, 0.3f);
            _gameManager.LivesDecr(1);
            allowDamage = false;
        }

        if (other.CompareTag("Spike")) {
            _audioSource.PlayOneShot(hitSound, 0.3f);
            _gameManager.LivesDecr(2);
            allowDamage = false;
        }

        if (other.CompareTag("Plate")) { 
            puzzleObj.GetComponent<puzzleCombi>().Input(other.gameObject);
            // change color of plate to green
            other.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1);
            allowDamage = false;
        }
    }
}
