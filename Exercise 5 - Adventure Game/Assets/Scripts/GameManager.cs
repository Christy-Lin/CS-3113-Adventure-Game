using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int lives = 3, health = 100;
    public static bool pause = false;
    public TextMeshProUGUI healthUI, livesUI;
    public GameObject pauseUI;

    private void Start()
    {
        healthUI.text = "HEALTH: " + health;
        livesUI.text = "LIVES: " + lives;
        pauseUI.SetActive(false);
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

    public void HealthDecr(int points) {
        health -= points;
        healthUI.text = "HEALTH: " + health;
        
        if (health <= 0)
        {
            lives -= 1;

            if (lives <= 0) {
                SceneManager.LoadScene("GameOver");
            }
            else {
                health = 100;
            
                healthUI.text = "HEALTH: " + health;
                livesUI.text = "LIVES: " + lives;
            }
 
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

    public void initPuzzleLock() {
        
    }

}