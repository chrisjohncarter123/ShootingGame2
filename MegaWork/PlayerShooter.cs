using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {


    public Gun gun;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gun.GetIsAutomatic())
        {
            if(Input.GetMouseButton(0)){
                gun.Shoot();
            }

        }
        else {
            if (Input.GetMouseButtonDown(0)){
                gun.Shoot();
            }
        }
		
	}
}
