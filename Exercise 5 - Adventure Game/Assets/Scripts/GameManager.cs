using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int lives = 10;
    public static bool pause = false;

    public TextMeshProUGUI livesUI;
    public GameObject pauseUI;
    private Vector3 original_position;

    private void Start()
    {
        
        original_position = GameObject.FindWithTag("Player").transform.position;

        //healthUI.text = "HEALTH: " + health;
        livesUI.text = "HEALTH: " + lives;
        pauseUI.SetActive(false);
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (pause) {
                Resume();
            }
            else {
                Pause();
            }
        }
    }

    public int GetLives() {
        return lives;
    }

    public void LivesDecr(int points) {
        lives -= points;
        livesUI.text = "HEALTH: " + lives;
        
        if (lives <= 0) {
            SceneManager.LoadScene("GameOver");
        }
        else {

           teleport();        
            //healthUI.text = "HEALTH: " + health;
            livesUI.text = "HEALTH: " + lives;
        }
    }

    public void Resume() {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        pause = false;
    }

    public void Pause() {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        pause = true;
    }

    public void teleport() {
        GameObject.FindWithTag("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(original_position);
    }

}