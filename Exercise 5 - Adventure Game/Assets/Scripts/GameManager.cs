using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int health = 3;
    public static bool pause = false;

    public TextMeshProUGUI healthUI;
    public GameObject pauseUI;

    private void Start()
    {
        healthUI.text = "LIVES: " + health;
        pauseUI.SetActive(false);
    }

    public void HealthDecr(int points) {
        health -= points;
        healthUI.text = "LIVES: " + health;
        if(health <= 0)
        {
            SceneManager.LoadScene("Game Over");
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

    public int GetHealth()
    {
        return health;
    }
}