using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    GameObject _mainManager;
    
    public bool locked = true;
    int ranInt;

    void Start() {
        // _mainManager = FindGameObjectWithTag("Main");
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (!locked) {
                ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
                SceneManager.LoadScene(ranInt);
            }
            if (PublicVars.hasKey) {
                PublicVars.hasKey = false;
                ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
                SceneManager.LoadScene("puzzleShoot");
            }
        }
    }
}
