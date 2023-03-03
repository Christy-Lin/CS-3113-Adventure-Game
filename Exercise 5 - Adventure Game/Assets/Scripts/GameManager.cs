using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private double lives = 5;
    public static bool pause = false;
    public TextMeshProUGUI livesUI;
    public GameObject pauseUI;

    private Vector3 original_position;

    private void Start()
    {
        
        original_position = GameObject.FindWithTag("Player").transform.position;

        //healthUI.text = "HEALTH: " + health;
        livesUI.text = "LIVES: " + lives;
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

    public double GetLives() {
        return lives;
    }

    public void LivesDecr(double points) {
        lives -= points;
        livesUI.text = "LIVES: " + lives;
        
        if (lives <= 0) {
            SceneManager.LoadScene("GameOver");
        }
        else {

            GameObject.FindWithTag("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(original_position);
        
            //healthUI.text = "HEALTH: " + health;
            livesUI.text = "LIVES: " + lives;
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