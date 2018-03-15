using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Gun : MonoBehaviour {

    public enum FireType{
        Bullet,
        Insant
    }

    public FireType fireType = FireType.Bullet;
    public int dammage;
    [SerializeField]
    ShootRecoil recoil;

    public GameObject[] randomBullet;
    public GameObject noBullets;
    public ParticleSystem muzzleFlare;
    public float fireSpeed;
    public Transform bulletStart;
    public bool infiniteBullets = false;
    const float bulletLife = 5;

    public AudioSource shootSound;

    [SerializeField]
    bool isAutomatic = true;

    int bulletsRemaining = 100;

    float lastShot = 0;
	// Use this for initialization
	void Start () {
        lastShot = 0;
	}
	
	// Update is called once per frame
	void Update () {


		
	}
    public bool GetIsAutomatic(){
        return isAutomatic;
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
                if (randomBullet.Length > 0)
                {
                    if (fireType == FireType.Bullet)
                    {
                        CreateBullet(randomBullet[Random.Range(0, randomBullet.Length)]);
                    }
                    else if(fireType == FireType.Insant){
                        RaycastHit hit;
                        Ray ray = new Ray(bulletStart.position, bulletStart.forward);

                        if (Physics.Raycast(ray, out hit))
                        {
                            if(hit.collider.gameObject.GetComponent<RobotBody>()){
                                hit.collider.gameObject.GetComponent<RobotBody>().Dammage(dammage, hit.point);
                            }
                        }
                    }
                }
                if (recoil)
                {
                    recoil.Recoil();
                }
                if(shootSound){
                    shootSound.Play();
                }
                if(muzzleFlare){
                    muzzleFlare.Play();
                }

            }
            else {
                if (noBullets)
                {
                    CreateBullet(noBullets);
                }
            }
            lastShot = Time.time;
        }
    }

    void CreateBullet(GameObject bulletObject){
        GameObject newBullet = Instantiate(
            bulletObject,
            bulletStart.position,
            Quaternion.Euler(bulletStart.eulerAngles)
                                           );
        newBullet.GetComponent<Bullet>().SetDammage(dammage);
        Destroy(newBullet, bulletLife);
    }


}
