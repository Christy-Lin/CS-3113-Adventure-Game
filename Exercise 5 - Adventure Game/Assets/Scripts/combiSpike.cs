using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class combiSpike : MonoBehaviour
{
    float speed = 1f;
    float height = 0.5f;
    float startTime, timeElapsed = 1f;

    bool move = false;
    Vector3 curr_position;

    void Start()
    {
        curr_position = transform.position;
    }

    void Update()
    {
        while ((Time.time - startTime <= timeElapsed) && move) {
            float newY = Mathf.Sin(Time.time * speed) * height + curr_position.y;
            transform.position = new Vector3(curr_position.x, newY, curr_position.z);
        }
    }

    public void Move() {
        startTime = Time.time;
        move = true;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
