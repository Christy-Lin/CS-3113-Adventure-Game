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
                //move spikes down and let player pass
            }
            position = 0;
        }
    }

    bool checkMatch() {
        for (int i = 0; i < answer.Length; ++i) {
            if (answer[i] != input[i]) {
                return false;
            }
        }
        return true;
    }

    public void Input(GameObject obj) {
        int index = findIndex(obj);
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