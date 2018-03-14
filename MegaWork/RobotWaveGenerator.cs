using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWaveGenerator : MonoBehaviour {
    public StateBranch endWave;

    public enum AddType{
        Linear,
        Log
    }
    public float time;
    public float timeAddPerWave;
    public AddType timeAddType;

    public float robotsCount;

    public int allRobotCount = 0;
    int totalRobots = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void AddToRobotCount(int add){
        robotsCount += add;
        if(robotsCount <= 0){
            endWave.StartBranch();
        }
    }
    private void NewRobotBuilder(int waveNumber){

        float t = time + timeAddPerWave * waveNumber;

        GameObject newObject = new GameObject();
        newObject.transform.parent = transform;
        newObject.name = "Robot Builder";
        RobotBuilder builder = newObject.AddComponent<RobotBuilder>();
        builder.SetRobotWaveGenerator(this);
    }
    public void StartNextWave(){
        allRobotCount = 0;
        int waveNumber = PlayerPrefs.GetInt("Wave", 1);
        NewRobotBuilder(waveNumber);

    }
}
