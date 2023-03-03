using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    //GameObject _mainManager;

    void Start() {
        //_mainManager = GameObject.FindGameObjectWithTag("Main");
    }

    public void Play() {
        //int ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
        int ranInt = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(ranInt);
    }
    
    public void Quit() {
        Application.Quit();
    }
}
