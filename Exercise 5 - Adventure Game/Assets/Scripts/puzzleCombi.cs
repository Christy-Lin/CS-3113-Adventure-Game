using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleCombi : MonoBehaviour
{
    GameManager _gameManager;
    
    GameObject[] plates;
    int[] answer = {0, 1,2,3,4};
    int[] input = new int[5];
    int position = 0;

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
            if (checkMatch()) {
                print("CheckMatch\n");
                traps.SetActive(false);
                //traps.GetComponent<combiSpike>().Move();
            }

            position = 0;
            //match = true;
        }

        // if plateCount (from Player.cs == 5, change material)
        if (GameObject.Find("Queen").GetComponent<Player>().plateCount >= 5) {
            foreach (GameObject plate in plates) {
                plate.GetComponent<Renderer>().material = plateOriginal;
            } 
        }
    }


    bool checkMatch() {
        for (int i = 0; i < answer.Length; ++i) {
            if (answer[i] != input[i]) {
                print("Fail\n");
                return false;
            }
        }
        print("Match\n");
        return true;
    }

    public void Input(GameObject obj) {
        int index = findVal(obj);
        print(index + "\n");
        if (index != plates.Length && position < answer.Length) {   // still input left for sequence
            input[position] = index;    // enter into input arr
            //match &= checkMatch(position);
            //print("match: " + match + "\n");

            position++;
        }
 
    }

    int findVal(GameObject obj) {
        for (int i = 0; i < plates.Length; ++i) {
            if (plates[i] == obj) {
                return obj.GetComponent<combiValue>().value;
            }
        }
        return plates.Length;
    }
}