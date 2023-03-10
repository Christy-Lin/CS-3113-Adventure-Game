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
    bool match = true;

    public GameObject traps;
    public Material plateOriginal;

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
            if (match) {
                print("CheckMatch\n");
                traps.SetActive(false);
                //traps.GetComponent<combiSpike>().Move();
            }

            position = 0;
            match = true;
        }

        // if plateCount (from Player.cs == 5, change material)
        if (GameObject.Find("Queen").GetComponent<Player>().plateCount >= 5) {
            foreach (GameObject plate in plates) {
                plate.GetComponent<Renderer>().material = plateOriginal;
            } 
        }
    }


    bool checkMatch(int i) {
        // for (int i = 0; i < answer.Length; ++i) {
            if (answer[i] != input[i]) {
                print("Fail\n");
                return false;
            }
        // }
        print("Match\n");
        return true;
    }

    public void Input(GameObject obj) {
        int index = findIndex(obj);
        print(index + "\n");
        if (index != plates.Length && position < answer.Length) {   // still input left for sequence
            input[position] = index;    // enter into input arr
            match &= checkMatch(position);
            print("match: " + match + "\n");

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