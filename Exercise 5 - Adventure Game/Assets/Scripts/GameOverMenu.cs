using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverMenu : MonoBehaviour
{
    GameObject _mainManager;

    void Start() {
        _mainManager = GameObject.FindGameObjectWithTag("Main");
    }

    public void Play() {
        int ranInt = _mainManager.GetComponent<RandomLevel>().RandomizeNextLevel();
        SceneManager.LoadScene(ranInt);
    }
    
    public void Quit() {
        Application.Quit();
    }
}
