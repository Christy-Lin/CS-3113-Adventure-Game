using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    GameManager _gameManager;
    AudioSource _audioSource;
    public AudioClip deathSfx;
    
    GameObject[] patterns;
    GameObject king, door, explosion;
    int position = 0;
    int health = 3;
    bool allowSwitch = true;
    float secSince = 0f;
    public float swapInterv = 1f;
    
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        patterns = GameObject.FindGameObjectsWithTag("Pattern");
        _audioSource = GetComponent<AudioSource>();
        door.SetActive(false);

        kingMissles();
        
        //GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
    }

    void Update()
    {

        if (Mathf.Sin(Time.time * 2f) == 0) {
            //cyclePatterns();
        }
        
        if (health == 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(deathSfx);
            door.SetActive(true);
            Destroy(king);
        }
    }

    public void bossHealth() {
        health--;
    }

    private void switchCheck() {
        if (!allowSwitch) {
            secSince += Time.deltaTime;
            
            if (secSince >= swapInterv) {
                allowSwitch = true;
                secSince = 0f;
            }
        }
    }

    private void cyclePatterns() {
        if (position > 0 ) {
            patterns[position-1].SetActive(false);
        }

        if (position == patterns.Length) {
            position = 0;
        }

        patterns[position].SetActive(true);
        print(position + "\n");
        position++;
    }

    void kingMissles() {
        GetComponent<BossShoot>().shoot(0);
        GetComponent<BossShoot>().shoot(1);
        GetComponent<BossShoot>().shoot(2);
        GetComponent<BossShoot>().shoot(3);
        GetComponent<BossShoot>().shoot(4);
    }

}
