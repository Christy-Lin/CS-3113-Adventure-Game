using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject missilePrefab;

    int missileSpeed = 360;
    float time = 1f;

    // Start is called before the first frame update
    public void shoot(int direc)
    {
        StartCoroutine(ShootMissile(direc));
    }

    public void stopShoot(int direc) {
        StopCoroutine(ShootMissile(direc));
    }

    IEnumerator ShootMissile(int direction) {
        // shoot.. wait 2 sec... shoot... etc.
        // yield return new WaitForSeconds(1);
        float elapsedTime = 0;

        while(elapsedTime < time) {

            GameObject newMissile = Instantiate(missilePrefab, spawnPoint.position, Quaternion.identity); //copies
            // if parent = pawnsLeft, shoot right
            if (direction == 0) {
                //yield return new WaitForSeconds(1);
                // newMissile.GetComponent<Rigidbody>().AddForce(transform.right, missileSpeed);
                newMissile.GetComponent<Rigidbody>().AddForce(new Vector3(missileSpeed, 0, 0));
                yield return new WaitForSeconds(1);
            }
            // if parent = pawnsRight, shoot left
            else if (direction == 1) {
                //yield return new WaitForSeconds(1);
                newMissile.GetComponent<Rigidbody>().AddForce(new Vector3(-missileSpeed, 0, 0));
                yield return new WaitForSeconds(1);
            }

            else if (direction == 2) {
                //yield return new WaitForSeconds(1);
                newMissile.GetComponent<Rigidbody>().AddForce(new Vector3(-missileSpeed, 0, -missileSpeed));
                yield return new WaitForSeconds(1);
            }

            else if (direction == 3) {
                //yield return new WaitForSeconds(1);
                newMissile.GetComponent<Rigidbody>().AddForce(new Vector3(missileSpeed, 0, -missileSpeed));
                yield return new WaitForSeconds(1);
            }

            else if (direction == 4) {
                //yield return new WaitForSeconds(1);
                newMissile.GetComponent<Rigidbody>().AddForce(new Vector3(0, 0, -missileSpeed));
                yield return new WaitForSeconds(1);
            }
            // yield return new WaitForSeconds(1);
            // yield return new WaitForSeconds(1.2f);
            
            elapsedTime += Time.deltaTime;
            yield return null;

        }
    }

}
