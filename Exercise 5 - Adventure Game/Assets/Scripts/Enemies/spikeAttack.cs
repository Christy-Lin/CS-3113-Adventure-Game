using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeAttack : MonoBehaviour
{
    float speed = 2f;
    float height = 0.8f;
    Vector3 curr_position;
    
    void Start() {
        //get current position
        curr_position = transform.position;
    }
    void Update() {
            float newY = Mathf.Sin(Time.time * speed) * height + curr_position.y;
            transform.position = new Vector3(curr_position.x, newY, curr_position.z); // * height;
    }


}

