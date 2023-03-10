using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{

    GameManager _gameManager;

    UnityEngine.AI.NavMeshAgent _navMeshAgent;
    Camera mainCam;
    public GameObject puzzleObj, bossFightObj, explosion;

    bool allowDamage = true;
    float secSinceLastDamage = 0.0f;
    public float allowDamageInterval = 0.5f;

    public AudioClip collectSound, deathSfx, hitSound; 
    AudioSource _audioSource;
    public Material purplePlate;
    public int plateCount = 0;

    void Start()
    {
        mainCam = Camera.main;
        _navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();

        if (puzzleObj) { //SceneManager.GetActiveScene().name == "puzzleCombination" &&
            //puzzleObj.GetComponent<puzzleCombi>().Start();
        }
    }

    void Update()
    {
        dmgCheck();
        if (_gameManager.GetLives() <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
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

    IEnumerator textPause() {
        yield return new WaitForSeconds(3);
        _gameManager.showDoorText("");
    }

    private void OnTriggerEnter(Collider other) {
        //picking up key
        if (other.CompareTag("Key")) {
            _audioSource.PlayOneShot(collectSound);
            _gameManager.GetComponent<GameManager>().KeyIncr();
            Destroy(other.gameObject);
        }

        //damage
        else if (other.CompareTag("Rook")) {
            if (allowDamage) { _gameManager.LivesDecr(1); }
            allowDamage = false;
        }

        else if (other.CompareTag("missile")) {
            _audioSource.PlayOneShot(hitSound, 0.3f);
            if (allowDamage) { _gameManager.LivesDecr(1); }
            allowDamage = false;
        }

        else if (other.CompareTag("Spike")) {
            _audioSource.PlayOneShot(hitSound, 0.3f);
            if (allowDamage) { _gameManager.LivesDecr(2); }
            allowDamage = false;
        }

        else if (other.CompareTag("Plate")) { 
            
            puzzleObj.GetComponent<puzzleCombi>().Input(other.gameObject);
            // change color of plate to purple (switch material)
            // other.GetComponent<Renderer>().material.color = new Color(1, 0.92f, 0.016f, 1);
            other.GetComponent<Renderer>().material = purplePlate;
            allowDamage = false;

            if (bossFightObj) {
                bossFightObj.GetComponent<BossFight>().bossHealth();
                Destroy(other.gameObject);
            }

            if (plateCount <= 4) {
                plateCount++;
            }
            else {
                plateCount = 1;
            }
            print("count:" + plateCount);
        }

        else if (other.CompareTag("Door")) {
            if (!PublicVars.hasKey) {
                _gameManager.showDoorText("Door is locked!");
            }
            StartCoroutine("textPause");
        }

        else if (other.CompareTag("WrongDoor")) {
            // _audioSource.PlayOneShot(hitSound, 0.3f);
            if (allowDamage) { _gameManager.LivesDecr(2); }
            allowDamage = false;
        }
    }
}
