using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovingAfterTime : MonoBehaviour {
    public float timeMin, timeMax = 1;
    float startTime, time;
	// Use this for initialization
	void Start () {
        time = Random.Range(timeMin, timeMax);
        startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time > startTime + time){
            if(GetComponent<LinearMover>()){
                GetComponent<LinearMover>().enabled = false;;
            }
        }
		
	}
}
