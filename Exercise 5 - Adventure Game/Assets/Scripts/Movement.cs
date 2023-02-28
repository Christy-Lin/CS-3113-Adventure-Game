using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int speed = 5;
    Rigidbody _rigidbody;
    private Vector3 startPos;
    bool check = false;
    
    void Start()
    {
        startPos = transform.position;
        _rigidbody = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        float xVeloc = Input.GetAxis("Horizontal") * speed;
        float zVeloc = Input.GetAxis("Vertical") * speed; 
        
        _rigidbody.AddForce(new Vector3(xVeloc,0,zVeloc));
    }

    private void OnCollisionEnter(Collision col) {
        if ((col.gameObject.name == "Red Area") || (col.gameObject.name == "Plane")) {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
            transform.position = startPos;
            _rigidbody.isKinematic = false;
        }
        else if (!check && col.gameObject.name == "CHECK") {
            startPos = col.transform.position;
            check = true;
        }
    }
}
