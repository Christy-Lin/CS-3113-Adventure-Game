using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool locked = true;
    public string levelToLoad;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (!locked) {
                SceneManager.LoadScene("puzzleShoot");
            }
            if (PublicVars.hasKey) {
                PublicVars.hasKey = false;
                SceneManager.LoadScene("puzzleShoot");
            }
        }
    }
}
