using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileDestroy : MonoBehaviour
{
    GameManager _gameManager;

    public AudioClip hitSound; 
    AudioSource audio;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        audio = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (this.transform.position.x > 8 || this.transform.position.x < -8 || 
        this.transform.position.y > 8 || this.transform.position.y < -8) {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            audio.PlayOneShot(hitSound);
            _gameManager.GetComponent<GameManager>().HealthDecr(10);
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
