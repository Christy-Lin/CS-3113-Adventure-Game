using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomLevel : MonoBehaviour
{
    public static RandomLevel _mainManager;
    List<int> visited = new List<int>(5);

    public int ranInt = 1;

    void Awake() {
        if (_mainManager) {
            Destroy(gameObject);
            return;
        }
        
        _mainManager = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //ranInt = SceneManager.GetActiveScene().buildIndex + 1; 
        RandomizeNextLevel();
    }

    public int RandomizeNextLevel() {
        System.Random random = new System.Random();
        int temp = random.Next(1,5);
        if (alreadyVisited(temp)) {
            RandomizeNextLevel();
        }

        visited.Add(temp);
        ranInt = temp;
        return temp;
    }

    bool alreadyVisited(int find) {
        for (int i = 0; i < visited.Count; ++i) {
            if (visited[i] == find) {
                return true;
            }
        }
        return false;
    }
}
