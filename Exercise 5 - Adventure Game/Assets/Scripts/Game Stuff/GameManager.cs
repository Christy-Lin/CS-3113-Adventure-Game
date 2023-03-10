using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    private int lives = 10;
    public static bool pause = false;

    public int totalKey = 12; // total key count in the level
    int keyTaken = 0; // keys collected by the player

    public TextMeshProUGUI livesUI, keysUI, doorUI;
    public GameObject pauseUI;
    private Vector3 original_position;
    public GameObject explosion;

    private void Start()
    {
        
        original_position = GameObject.FindWithTag("Player").transform.position;
        pauseUI.SetActive(false);
        //GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();

        livesUI.text = "HEALTH: " + lives;
        keysUI.text = "KEYS: " + keyTaken + "/" + totalKey;

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
            string scene = SceneManager.GetActiveScene().name;
            if (scene != "puzzleChoose") {
                Vector3 current_position = GameObject.FindWithTag("Player").transform.position;
                GameObject death = Instantiate(explosion, new Vector3(current_position.x, 1, current_position.z), Quaternion.identity);
                Destroy(death, 0.5f);
                Invoke("teleport", 0.5f);
            } else {
                teleport();
            }
            //healthUI.text = "HEALTH: " + health;
            livesUI.text = "HEALTH: " + lives;
        }
    }



    public void teleport() {
        GameObject.FindWithTag("Player").GetComponent<UnityEngine.AI.NavMeshAgent>().Warp(original_position);
    }



    public void showDoorText(string text) {
        doorUI.text = text;
    }


    public int getKeys() {
        return keyTaken;
    }

    public void KeyIncr() {
        keyTaken++;
        keysUI.text = "KEYS: " + keyTaken + "/" + totalKey;
        if (keyTaken == totalKey) {
            PublicVars.hasKey = true;
        }
    }



    public void PlayGame() {
        //Debug.Log("Yay, you did it! Moving to " + sceneToLoad);
        //int ranInt = SceneManager.GetActiveScene().buildIndex + 1;
       // SceneManager.LoadScene(ranInt);
       SceneManager.LoadScene(1);
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

    public void QuitGame() {
        Application.Quit();
    }
}