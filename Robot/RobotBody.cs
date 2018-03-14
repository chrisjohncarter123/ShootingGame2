using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBody : MonoBehaviour {
    GameObject robotParent;
    public int moneyReward = 10;
    public Transform eyesPosition, nosePosition, mouthPosition, shooterPosition;
    public GameObject deathObject;
    public int maxHealth = 3;
    int currentHealth;
    RobotWaveGenerator wave;


    public void SetRobotWaveGenerator(RobotWaveGenerator wave){
        this.wave = wave;
    }
	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Bullet>()){
            int dammage = other.GetComponent<Bullet>().GetDammage();

            Dammage(dammage);

        }
    }

    public void SetRobotParent(GameObject robotParent){
        this.robotParent = robotParent;
    }
    private void DetachPart(Transform part){
        
    }

    private void Dammage(int dammage){
        currentHealth -= dammage;

        if(currentHealth == 0){
            DestroyRobot();
        }
    }

    private void DestroyRobot(){
        PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + moneyReward);
        Instantiate(deathObject, transform.position, Quaternion.identity);
//        wave.AddToRobotCount(-1);
        Destroy(robotParent);
    }
}
