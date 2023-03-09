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
        SceneManager.LoadScene(1);
    }
    
    public void Quit() {
        Application.Quit();
    }
}
