using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour {


    public Gun gun;
    bool isShooting = false;
	// Use this for initialization
	void Start () {
        EndShoot();
		
	}
    public void StartShoot(){
        isShooting = true;

    }

    public void EndShoot(){
        isShooting = false;
    }
	// Update is called once per frame
	void Update () {
        gun.dammage = PlayerShop.GetDammage();
        gun.fireSpeed = 1 / ( Mathf.Log(5 + PlayerShop.GetSpeed()));

        if (isShooting)
        {
            gun.gameObject.SendMessage("Shoot");
        }

        /*
        if (gun.GetIsAutomatic())
        {
            

        }
        else {
            if (Input.GetMouseButtonDown(0)){
                gun.gameObject.SendMessage("Shoot");
            }
        }
        */
		
	}
}
