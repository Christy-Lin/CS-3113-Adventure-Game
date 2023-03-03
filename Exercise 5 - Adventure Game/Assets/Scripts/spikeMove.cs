using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class spikeMove : MonoBehaviour
{
    public float speed;
    public float distance;
    public string direction;
    Vector3 curr_position;
    GameManager _gameManager;
    
    void Start() {
        //get current position
        curr_position = transform.position;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }
    
    void Update() {
            if (direction == "X") {
                float newX = Mathf.Sin(Time.time * speed) * distance + curr_position.x;
                transform.position = new Vector3(newX, curr_position.y, curr_position.z);
            }
            else if (direction == "Y") {
                float newY = Mathf.Sin(Time.time * speed) * distance + curr_position.y;
                transform.position = new Vector3(curr_position.x, newY, curr_position.z);
            }
            else {  // direction == "Z"
                float newZ = Mathf.Sin(Time.time * speed) * distance + curr_position.z;
                transform.position = new Vector3(curr_position.x, curr_position.y, newZ);
            }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            _gameManager.GetComponent<GameManager>().LivesDecr(1);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}