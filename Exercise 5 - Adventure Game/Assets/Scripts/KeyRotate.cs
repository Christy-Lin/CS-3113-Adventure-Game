using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyRotate : MonoBehaviour
{
    // this script will make pickup game object spin while game active...
    // translate moves game object by its transform
    // rotate rotates game object by its transform.. 2 possible params(vector3 or 3 floats)

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 15) * Time.deltaTime); // deltatime makes sure actions happen smoothly
    }
}