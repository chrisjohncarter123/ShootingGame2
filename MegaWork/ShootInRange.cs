using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInRange : MonoBehaviour {


    public Gun gun;
    public float timeBeforeShoot = 2;

    float startTime;
	// Use this for initialization
	void Start () {
        startTime = Time.time;
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time >= timeBeforeShoot + startTime)
        {
            gun.Shoot();
        }
		
	}
}
