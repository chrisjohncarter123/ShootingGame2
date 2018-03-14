using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotWaveGenerator : MonoBehaviour {

    public enum AddType{
        Linear,
        Log
    }
    public float time;
    public float timeAddPerWave;
    public AddType timeAddType;

    public float robotsCount;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateWave(int waveNumber){
        float t = time + timeAddPerWave * waveNumber;
    }
}
