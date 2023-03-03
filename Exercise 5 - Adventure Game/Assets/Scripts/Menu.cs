using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{

    public GameObject _gameManager;

    public void PlayGame() {
        //Debug.Log("Yay, you did it! Moving to " + sceneToLoad);
        int ranInt = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(ranInt);
        
    }

    public void Resume() {
        _gameManager.GetComponent<GameManager>().Resume();
    }

/*
    public void Restart()
    {
        SceneManager.LoadScene("Level1");
    }
*/

    public void QuitGame() {
        Application.Quit();
    }
}
