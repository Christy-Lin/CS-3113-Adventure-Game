using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    GameManager _gameManager;

    bool allowDamage = true;
    float secSinceLastDamage = 0.0f;
    public float allowDamageInterval = 1.0f;

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update() {
        if (_gameManager.GetHealth() <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            _audioSource.PlayOneShot(deathSfx);
            Destroy(gameObject);
        }
        

        if (!allowDamage) {
            secSinceLastDamage += Time.deltaTime;
            
            if (secSinceLastDamage >= allowDamageInterval) {
                allowDamage = true;
                secSinceLastDamage = 0f;
            }
        }
    }
    void OnCollisonEnter(Collision col) {
        if (col.compareTag("Rook") || col.compareTag("missle")) {
            _gameManager.HealthDecr(1);
            allowDamage = false;
        }
    }
}
