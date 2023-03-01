using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinuousShooter : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject missilePrefab;

    int missileSpeed = 500;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShootMissile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ShootMissile() {
        // shoot.. wait 2 sec... shoot... etc.
        yield return new WaitForSeconds(0.5f);
        while(true) {
            GameObject newMissile = Instantiate(missilePrefab, spawnPoint.position, Quaternion.identity); //copies
            // if parent = pawnsLeft, shoot right
            if (transform.parent.name == "pawnsLeft") {
                // newMissile.GetComponent<Rigidbody>().AddForce(transform.right, missileSpeed);
                newMissile.GetComponent<Rigidbody>().AddForce(new Vector3(missileSpeed, 0, 0));
            }
            // if parent = pawnsRight, shoot left
            // if (transform.parent.name == "pawnsRight") {
            //     newMissile.GetComponent<Rigidbody>().AddForce(new Vector3(-missileSpeed, 0, 0));
            // }
        }
    }


}
