using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MissileDestroy : MonoBehaviour
{
    GameManager _gameManager;

    public AudioClip hitSound; 
    AudioSource _audioSource;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        _audioSource = GetComponent<AudioSource>();
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
            _audioSource.PlayOneShot(hitSound);
            _gameManager.GetComponent<GameManager>().LivesDecr(1);
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
