using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked = true;
    int ranInt;

    void Start() {
        _mainManager = FindGameObjectWithTag("Main");
    }

    private void OnTriggerEnter(Collider other) {   
        if (other.gameObject.CompareTag("Player")) {
            if (!locked) {
                //ranInt = RandomLevel._mainManager.ranInt;
                //ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
                SceneManager.LoadScene(ranInt);
            }
            if (PublicVars.hasKey) {
                PublicVars.hasKey = false;
                //ranInt = RandomLevel._mainManager.ranInt;
                //ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
                SceneManager.LoadScene("puzzleShoot");
            }
        }
    }
}
