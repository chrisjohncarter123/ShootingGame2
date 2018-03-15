using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBody : MonoBehaviour {
    //public Material bodyMaterial;
    GameObject robotParent;
    public int moneyReward = 10;
    public Transform foodPosition, eyesPosition, nosePosition, mouthPosition, shooterPosition;
    public GameObject deathObject;
    public GameObject hitObject;
    public int maxHealth = 3;
    int currentHealth;
    RobotWaveGenerator wave;
    RobotBuilder robotBuilder;


    public static int moneyEarnedThisWave = 0;

    public void SetRobotBuilder(RobotBuilder robotBuilder){
        this.robotBuilder = robotBuilder;
    }
    public void SetRobotWaveGenerator(RobotWaveGenerator wave){
        this.wave = wave;
    }
	// Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
        float red = HealthPercentage() * 255;
        Color color = new Color(red, 255, 255);

        bodyMaterial.SetColor("_Tint", color);
        */
        if(!wave.playerHealth.GetIsAlive()){
            Destroy(robotParent);
        }
        if(Vector3.Distance(transform.position, wave.playerHealth.transform.position) <= 2){
            wave.playerHealth.Dammage(1);
            DestroyRobot(false);
        }
		
	}
    float HealthPercentage(){
        return currentHealth / maxHealth;
    }
    public void SetHealth(int health){
        maxHealth = health;
        currentHealth = maxHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<Bullet>()){
            if (other.GetComponent<Bullet>().GetBulletType() == Bullet.BulletType.Player)
            {
                int dammage = other.GetComponent<Bullet>().GetDammage();

                Dammage(dammage, other.transform.position);
            }

        }
        else if(other.GetComponent<PlayerHealth>()){
            other.GetComponent<PlayerHealth>().Dammage(1);
            DestroyRobot(false);

        }

    }
    public static int GetTotalMoneyEarnedThisWave(){
        return moneyEarnedThisWave;
    }
    public static void ResetTotalMoneyEarnedThisWave(){
        moneyEarnedThisWave = 0;
    }
    public void SetRobotParent(GameObject robotParent){
        this.robotParent = robotParent;
    }


    public void Dammage(int dammage, Vector3 hitPosition){
        currentHealth -= dammage;
        Debug.Log("Dammage " + dammage);

        if (hitObject)
        {
            Instantiate(hitObject, hitPosition, hitObject.transform.rotation);
        }

        if(currentHealth == 0){
            DestroyRobot(true);
        }



    }

    private void DestroyRobot(bool money){
        robotBuilder.DecrementRemainingRobots();
        if (money)
        {
            moneyEarnedThisWave += moneyReward;
        }
        Instantiate(deathObject, transform.position, Quaternion.identity);
//        wave.AddToRobotCount(-1);
        Destroy(robotParent);
    }
}
