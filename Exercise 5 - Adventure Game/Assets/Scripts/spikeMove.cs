using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikeMove : MonoBehaviour
{
    float speed = 1f;
    float height = 0.5f;
    Vector3 curr_position;
    
    void Start() {
        //get current position
        curr_position = transform.position;
    }
    void Update() {
            // //get current position
            // Vector3 curr_position = transform.position;
            //calculate Y pos
            float newY = Mathf.Sin(Time.time * speed) * height + curr_position.y;
            // set Y to new Y
            transform.position = new Vector3(curr_position.x, newY, curr_position.z); // * height;
    }


}

