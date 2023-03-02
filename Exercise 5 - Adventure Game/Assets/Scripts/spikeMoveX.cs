using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikeMoveX : MonoBehaviour
{
    float speed = 2f;
    float width = 1f;
    Vector3 curr_position;
    
    void Start() {
        //get current position
        curr_position = transform.position;
    }
    void Update() {
            float newX = Mathf.Sin(Time.time * speed) * width + curr_position.x;
            // set Y to new Y
            transform.position = new Vector3(newX, curr_position.y, curr_position.z); // * height;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}