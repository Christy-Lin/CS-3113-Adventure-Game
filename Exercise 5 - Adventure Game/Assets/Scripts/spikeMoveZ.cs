using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spikeMoveZ : MonoBehaviour
{
    float speed = 2f;
    float depth = 2f;
    Vector3 curr_position;
    
    void Start() {
        //get current position
        curr_position = transform.position;
    }
    void Update() {
            float newZ = Mathf.Sin(Time.time * speed) * depth + curr_position.z;
            // set Y to new Y
            transform.position = new Vector3(curr_position.x, curr_position.y, newZ); // * height;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}