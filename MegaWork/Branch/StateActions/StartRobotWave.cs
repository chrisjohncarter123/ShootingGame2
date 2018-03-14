using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartRobotWave : MonoBehaviour {


    [SerializeField]
    RobotWaveGenerator wave;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    public void StartState()
    {
        wave.StartNextWave();
    }
    public void EndState()
    {
        
    }
}
