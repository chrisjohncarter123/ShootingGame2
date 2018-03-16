using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotBuilder : MonoBehaviour {

    [SerializeField]
    bool addFace = false;

    [SerializeField]
    bool addShooter = false;

    [SerializeField]
    bool addFood = false;

    RobotWaveGenerator wave;
    public GameObject[] bodies;
    public GameObject[] foods;
    public GameObject[] eyes;
    public GameObject[] mouths;
    public GameObject[] noses;
    public GameObject[] movers;
    public GameObject[] shooters;

    public float creationRadiusX = 4;
    public float creationRadiusY = 4;

    public Transform robotStartingPosition;

    public int totalRobots = 10;
    public float waitTimeMin, waitTimeMax;
    float waitTime;
    float lastRobotCreate = 0;
    int remainingRobots;
    int health;
    public int moneyRewardPerKill;

    public void SetHealth(int health){
        this.health = health;
    }
    public void SetRobotWaveGenerator(RobotWaveGenerator wave)
    {
        this.wave = wave;
    }
	// Use this for initialization
	void Start () {
		
	}
	
    void RandomizeWaitTime(){
        waitTime = Random.Range(waitTimeMin, waitTimeMax);
    }
	// Update is called once per frame
	void Update () {
        if (!IsFinished())
        {
            if (Time.time >= lastRobotCreate + waitTime)
            {
                RandomizeWaitTime();
                lastRobotCreate = Time.time;
                BuildRobot();
                totalRobots--;

            }
        }
		
	}

    public void DecrementRemainingRobots(){
        remainingRobots -= 1;
    }
    public int GetReminingRobots(){
        return remainingRobots;
    }
    public void SetRemainingRobots(int remainingRobots){
        this.remainingRobots = remainingRobots;
    }
    public void SetRobots(int robots){
        this.totalRobots = robots;
        this.remainingRobots = robots;
        RandomizeWaitTime();
    }
    public bool IsFinished(){
        return (totalRobots <= 0);
    }
    private Vector3 RandomizeStartingPosition(){

        Vector2 circle = Random.insideUnitCircle;
        circle.x *= creationRadiusX;
        circle.y *= creationRadiusY;
        circle.x += robotStartingPosition.position.x;
        circle.y += robotStartingPosition.position.y;
        return new Vector3(circle.x, circle.y, robotStartingPosition.transform.position.z);
    }
    public void BuildRobot(){


       // wave.AddToRobotCount(1);

        GameObject mover = Instantiate(
            movers[Random.Range(0, movers.Length)],
            transform.position,
            Quaternion.identity);
//        Debug.Log(mover.transform.position);
        mover.transform.parent = transform;
        mover.transform.localPosition = new Vector3(0, 0, 0);


        int bodyIndex = Random.Range(0, bodies.Length);
        GameObject body = Instantiate(
            bodies[bodyIndex],
            Vector3.zero,
            bodies[bodyIndex].transform.rotation);
        body.transform.parent = mover.transform;
        body.transform.localPosition = Vector3.zero;


        RobotBody robotBody = body.GetComponent<RobotBody>();
        robotBody.SetRobotParent(mover);
        robotBody.SetRobotBuilder(this);
        robotBody.SetRobotWaveGenerator(wave);
        robotBody.SetHealth(health);

        if (addFood)
        {
            GameObject food = Instantiate(foods[Random.Range(0, foods.Length)], robotBody.foodPosition.position, robotBody.foodPosition.rotation);
            food.transform.parent = robotBody.foodPosition;
        }

        if (addShooter)
        {
            GameObject shooter = Instantiate(shooters[Random.Range(0, shooters.Length)], robotBody.shooterPosition.position, robotBody.shooterPosition.rotation);
            shooter.transform.parent = robotBody.shooterPosition;
        }

        if (addFace)
        {
            GameObject eye = Instantiate(eyes[Random.Range(0, eyes.Length)], robotBody.eyesPosition.position, robotBody.eyesPosition.rotation);
            eye.transform.parent = robotBody.eyesPosition;
            GameObject nose = Instantiate(noses[Random.Range(0, noses.Length)], robotBody.nosePosition.position, robotBody.nosePosition.rotation);
            nose.transform.parent = robotBody.nosePosition;
            GameObject mouth = Instantiate(mouths[Random.Range(0, mouths.Length)], robotBody.mouthPosition.position, robotBody.mouthPosition.rotation);
            mouth.transform.parent = robotBody.mouthPosition;
        }
       

    }
}
