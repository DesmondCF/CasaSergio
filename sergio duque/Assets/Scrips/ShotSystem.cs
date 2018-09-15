using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSystem : MonoBehaviour {

    public GameObject pref_Bullet;
    GameObject bullet;

    public Transform spawnPoint;
    public float force;

    // Use this for initialization
    private void Update() { 

        if (Input.GetMouseButtonDown(0))
        {
            Shot();
        }
	}
	
	// Update is called once per frame
	void Shot () {
        bullet = Instantiate(pref_Bullet, spawnPoint.position,Quaternion.identity);
        bullet.AddComponent<Rigidbody>();
        bullet.GetComponent<Rigidbody>().AddForce(spawnPoint.forward *force, ForceMode.Impulse);
        Destroy(bullet, 5f);
		
	}
}
