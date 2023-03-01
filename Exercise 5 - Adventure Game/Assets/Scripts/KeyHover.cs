using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHover : MonoBehaviour
{
    // this script will make jewels float while game active...

    float speed = 2f;
    float height = 0.1f;
    Vector3 pos;
    private void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // new Y position 
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set Y to the new calculated Y
        transform.position = new Vector3(transform.position.x, newY, transform.position.z) ;
    }
}