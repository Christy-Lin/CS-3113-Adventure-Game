using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.SceneManagement;

public class combiSpike : MonoBehaviour
{
    //float speed = 1f;
    float height = -3f;
    float startTime, timeElapsed = 1.5f;
    bool move = false;
    bool collide;

    Vector3 curr_position;
    GameManager _gameManager;

    void Start()
    {
        curr_position = transform.position;
        collide = true;
        _gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    void Update()
    {
        if (move && (Time.time <= startTime + timeElapsed)) {
            print((Time.time - startTime) + "\n");
            print(Time.time - startTime <= timeElapsed);
            transform.position = new Vector3(curr_position.x, height, curr_position.z);
            collide = false;
            print("\n" + collide);
        }
    }

    public void Move() {
        startTime = Time.time;
        print(startTime + "\n");
        move = true;
    }

/*     private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && collide) {
            print("\n" + collide);
            print("\ncollided");
            _gameManager.GetComponent<GameManager>().LivesDecr(2);
            _gameManager.GetComponent<GameManager>().teleport();
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    } */
}
