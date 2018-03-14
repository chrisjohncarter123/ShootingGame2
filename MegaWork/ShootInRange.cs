using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInRange : MonoBehaviour {


    public Gun gun;
    public float zPosMax, zPosMin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.z > zPosMax || transform.position.z < zPosMin)
        {
            gun.Shoot();
        }
		
	}
}
