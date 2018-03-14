using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    [SerializeField]
    ShootRecoil recoil;

    public GameObject bullet;
    public GameObject noBullets;
    public float fireSpeed;
    public Transform bulletStart;
    public bool infiniteBullets = false;
    const float bulletLife = 5;

    int bulletsRemaining = 100;

    float lastShot = 0;
	// Use this for initialization
	void Start () {
        lastShot = 0;
	}
	
	// Update is called once per frame
	void Update () {


		
	}
    public int GetBulletsRemaining(){
        return bulletsRemaining;
    }
    public void Shoot(){
        if (Time.time > lastShot + fireSpeed)
        {
            if (bulletsRemaining > 0 || infiniteBullets == true)
            {
                bulletsRemaining -= 1;
                CreateBullet(bullet);
                if (recoil)
                {
                    recoil.Recoil();
                }

            }
            else {
                CreateBullet(noBullets);
            }
            lastShot = Time.time;
        }
    }

    void CreateBullet(GameObject bulletObject){
        GameObject newBullet = Instantiate(
                                           bullet,
                                           bulletStart.position,
                                           Quaternion.Euler(bulletStart.eulerAngles)
                                           );

        Destroy(newBullet, bulletLife);
    }

}
