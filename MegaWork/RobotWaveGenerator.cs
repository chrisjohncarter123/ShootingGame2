using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWaveGenerator : MonoBehaviour {
    public float builderY = 5;
    public float builderRaidus = 40;
    public float builderDegrees;
    public GameObject[] winObjectsActivate;
    public GameObject[] winObjectsDeactivate;
    public GameObject[] builders;

    public int robotsCountStart = 2;
    public int robotsAddPerWave = 3;
    public int startingBuilders = 1;
    public int wavesPerNewBuilder = 5;
    public float degreesPerWave = 10;
    public float startingDegrees = 90;
    public int startingHealth = 1;
    public int healthPerWave = 1;
    public int moneyPerKillPerWave = 10;

    public PlayerHealth playerHealth;

 //   public float robotsCount;

  //  public int allRobotCount = 0;
    int totalRobots = 0;
    bool ended = false;
    List<RobotBuilder> waveBuilders;
    bool started = false;
	// Use this for initialization
	void Start () {
        waveBuilders = new List<RobotBuilder>();
        ClearAllWaveBuilders();
        RobotBody.ResetTotalMoneyEarnedThisWave();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(started && IsAllFinished() && !ended){
            for (int i = 0; i < winObjectsActivate.Length; i++)
            {
                winObjectsActivate[i].SetActive(true);
            }

            for (int i = 0; i < winObjectsDeactivate.Length; i++)
            {
                winObjectsDeactivate[i].SetActive(false);
            }
            //PlayerPrefs.SetInt("Wave", PlayerPrefs.GetInt("Wave, 1") + 1);
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money", 0) + RobotBody.GetTotalMoneyEarnedThisWave());
            RobotBody.ResetTotalMoneyEarnedThisWave();
            ended = true;

        }

	}
    bool IsAllFinished(){
        int robotsRemaining = 0;
        for (int i = 0; i < waveBuilders.Count; i++)
        {
            Debug.Log(waveBuilders[i].name + " " + waveBuilders[i].GetReminingRobots());
            robotsRemaining += waveBuilders[i].GetReminingRobots();
        }
         

        Debug.Log(robotsRemaining == 0);
        return (robotsRemaining == 0);
    }
    /*
    public void AddToRobotCount(int add){
        robotsCount += add;
        if(robotsCount <= 0){
            endWave.StartBranch();
        }
    }
*/
    /*
    private void NewRobotBuilder(int waveNumber){

        float t = time + timeAddPerWave * waveNumber;

        GameObject newObject = new GameObject();
        newObject.transform.parent = transform;
        newObject.name = "Robot Builder";
        RobotBuilder builder = newObject.AddComponent<RobotBuilder>();
        builder.SetRobotWaveGenerator(this);
    }
    */
    void ClearAllWaveBuilders(){
        waveBuilders = new List<RobotBuilder>();
        for (int i = 0; i < waveBuilders.Count; i++)
        {
            Destroy(waveBuilders[i].gameObject);
        }



    }
    public void EndWave(){
        ClearAllWaveBuilders();
        playerHealth.ResetHealth();
    }
    //[SerializeField]
    //float addDegrees;
    public void StartNextWave(){
        started = true;
        playerHealth.ResetHealth();

        ended = false;
        int level = PlayerPrefs.GetInt("Level", 1);

        int robotsThisWave = robotsCountStart + (level * robotsAddPerWave);
        int buildersThisWave = startingBuilders + (level / wavesPerNewBuilder);
        builderDegrees = startingDegrees + (level * degreesPerWave);
        waveBuilders = new List<RobotBuilder>();
        for (int i = 0; i < buildersThisWave; i++){
            GameObject newBuilder = Instantiate(builders[Random.Range(0, builders.Length)]);
            waveBuilders.Add(newBuilder.GetComponent<RobotBuilder>());
            newBuilder.GetComponent<RobotBuilder>().SetRobotWaveGenerator(this);
            newBuilder.GetComponent<RobotBuilder>().SetHealth(startingHealth + level * healthPerWave);
            newBuilder.GetComponent<RobotBuilder>().moneyRewardPerKill = moneyPerKillPerWave * level;

            int robotsThisBuilder = robotsThisWave / builders.Length;
            newBuilder.GetComponent<RobotBuilder>().SetRobots(robotsThisBuilder);
            float totalRadians = builderDegrees * Mathf.Rad2Deg;


            float radians = totalRadians * 2  * i / (buildersThisWave);
           
            //radians += Mathf.Deg2Rad * addDegrees;
            newBuilder.transform.position = new Vector3(
                builderRaidus * Mathf.Cos(radians),
                builderY,
                builderRaidus * Mathf.Sin(radians)
            );
        }



    }
}
