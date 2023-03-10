using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    GameManager _gameManager;
    AudioSource _audioSource;
    public AudioClip deathSfx;
    
    GameObject[] patterns;
    public GameObject king, key, door, explosion;
    int position = 0;
    int health = 3;
    //float time = 1f;

    bool allowSwitch = true;
    float secSince = 0.0f;
    float swapInterv = 5f;
    
    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        patterns = GameObject.FindGameObjectsWithTag("Pattern");
        _audioSource = GetComponent<AudioSource>();

        for(int i = 0; i < patterns.Length; ++i) {
            patterns[i].SetActive(false);
        }
        door.SetActive(false);
        key.SetActive(false);

        kingMissles(true);
        //GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
    }

    void Update()
    {
        switchCheck();
        if(allowSwitch) { cyclePatterns(); }
    }

    public void bossHealth() {
        health--;
        
        if (health == 0) {
            allowSwitch = false;
            GameObject temp = Instantiate(explosion, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(deathSfx);

            for(int i = 0; i < patterns.Length; ++i) {
                patterns[i].SetActive(false);
            }

            Destroy(king);
            Destroy(temp);
            key.SetActive(true);
            door.SetActive(true);
            Destroy(gameObject);
        }
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
        allowSwitch = false;
        position++;
    }

    void kingMissles(bool shoot) {
        if (shoot) {
            GetComponent<BossShoot>().shoot(0);
            GetComponent<BossShoot>().shoot(1);
            GetComponent<BossShoot>().shoot(2);
            GetComponent<BossShoot>().shoot(3);
            GetComponent<BossShoot>().shoot(4);
        }
        else if (!shoot) {
            GetComponent<BossShoot>().stopShoot(0);
            GetComponent<BossShoot>().stopShoot(1);
            GetComponent<BossShoot>().stopShoot(2);
            GetComponent<BossShoot>().stopShoot(3);
            GetComponent<BossShoot>().stopShoot(4);
        }
    }
}
