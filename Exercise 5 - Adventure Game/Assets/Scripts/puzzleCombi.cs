using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCombi : MonoBehaviour
{
    GameManager _gameManager;
    
    GameObject[] plates;
    int[] answer = {1,4,3,0,2};
    int[] input = new int[5];
    int position = 0;

    public GameObject traps;

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _gameManager = GameObject.FindObjectOfType<GameManager>();
        plates = GameObject.FindGameObjectsWithTag("Plate");
    }


    void Update()
    {
        if (position == answer.Length) {
            if (checkMatch()) {
                print("CheckMatch\n");
                traps.GetComponent<combiSpike>().Move();
            }
            else {
                // if not a match, change the color of object with tag "Plate" to original color
                // original color: (0, 0.7992163, 1, 1)
                foreach (GameObject plate in plates) {
                    plate.GetComponent<Renderer>().material.color = new Color(0, 0.7992163f, 1, 1);
                }
            }
            position = 0;
        }
    }

    bool checkMatch() {
        for (int i = 0; i < answer.Length; ++i) {
            if (answer[i] != input[i]) {
                print("Fail\n");
                return false;
            }
        }
        print("Congrats\n");
        return true;
    }

    public void Input(GameObject obj) {
        int index = findIndex(obj);
        print(index + "\n");
        if (index != plates.Length && position < answer.Length) {
            input[position] = index;
            position++;
        }
    }

    int findIndex(GameObject obj) {
        for (int i = 0; i < plates.Length; ++i) {
            if (plates[i] == obj) {
                return i;
            }
        }
        return plates.Length;
    }
}