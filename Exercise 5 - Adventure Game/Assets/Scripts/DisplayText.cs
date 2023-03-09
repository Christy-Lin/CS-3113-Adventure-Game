using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayText : MonoBehaviour
{
    public GameObject text; // text - "Door is locked!"
    void Start()
    {
        text.SetActive(false);  // don't show at start
    }

    void Update() {
        if (PublicVars.hasKey == true) {
            text.SetActive(false); 
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            if (PublicVars.hasKey == false) {
                text.SetActive(true); // show when the player collides with the door.
                StartCoroutine("Pause"); // show it for 4 seconds
            }
        }
    }

    IEnumerator Pause() {
        yield return new WaitForSeconds(3);
        text.SetActive(false); 
        // Destroy(text);
    }
}
