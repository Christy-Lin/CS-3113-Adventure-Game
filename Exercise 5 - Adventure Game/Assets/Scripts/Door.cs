using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked = true;
    int ranInt;

    public AudioClip nextSound; 
    AudioSource audio;

    void Start() {
        // _mainManager = FindGameObjectWithTag("Main");
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other) {   
        if (other.gameObject.CompareTag("Player")) {
            if (!locked) {
                audio.PlayOneShot(nextSound);
                //ranInt = RandomLevel._mainManager.ranInt;
                //ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
                ranInt = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(ranInt);
            }
            if (PublicVars.hasKey) {
                audio.PlayOneShot(nextSound);
                PublicVars.hasKey = false;
                //ranInt = RandomLevel._mainManager.ranInt;
                //ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
                ranInt = SceneManager.GetActiveScene().buildIndex + 1;
                SceneManager.LoadScene(ranInt);
            }
        }
    }
}
