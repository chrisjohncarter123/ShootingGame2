using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWaveGenerator : MonoBehaviour {
    public float builderY = 5;
    public float builderRaidus = 40;
    public float builderDegrees = 180;
    public StateBranch endWave;
    public GameObject[] builders;

    public int robotsCountStart;
    public int robotsAddPerWave;
    public int startingBuilders = 3;
    public int wavesPerNewBuilder = 2;

 //   public float robotsCount;

  //  public int allRobotCount = 0;
    int totalRobots = 0;
    bool ended = false;
    List<RobotBuilder> waveBuilders;

	// Use this for initialization
	void Start () {
        waveBuilders = new List<RobotBuilder>();
        ClearAllWaveBuilders();
		
	}
	
	// Update is called once per frame
	void Update () {
        if(IsAllFinished() && !ended){
            endWave.StartBranch();
            ended = true;

        }
	}
    bool IsAllFinished(){
        bool returnValue = false;
        for (int i = 0; i < waveBuilders.Count; i++)
        {
            EndWave();
            returnValue = returnValue && waveBuilders[i].IsFinished();
        }
        return returnValue;
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
    }
    public void StartNextWave(){
        ended = false;
        int wave = PlayerPrefs.GetInt("Wave", 1);

        int robotsThisWave = robotsCountStart + (wave * robotsAddPerWave);
        int buildersThisWave = startingBuilders + (wave / wavesPerNewBuilder);

        waveBuilders = new List<RobotBuilder>();
        for (int i = 0; i < buildersThisWave; i++){
            GameObject newBuilder = Instantiate(builders[Random.Range(0, builders.Length)]);
            waveBuilders.Add(newBuilder.GetComponent<RobotBuilder>());

            int robotsThisBuilder = robotsThisWave / builders.Length;
            newBuilder.GetComponent<RobotBuilder>().SetRobots(robotsThisBuilder);
            float totalRadians = builderDegrees * Mathf.Rad2Deg;

            float radians = totalRadians * 2  * i / (buildersThisWave);
            newBuilder.transform.position = new Vector3(
                builderRaidus * Mathf.Cos(radians),
                builderY,
                builderRaidus * Mathf.Sin(radians)
            );
        }



    }
}
