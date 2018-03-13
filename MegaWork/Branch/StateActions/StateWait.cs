using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateWait : MonoBehaviour {
    public float time;
    float startTime = -1.0f;
    bool running = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(!running){
            return;
        }
        if(Time.time > startTime + time){
            GetComponent<State>().SendMessageToBranch("NextState");
            EndState();
        }
		
	}

    public void StartState(){
        startTime = Time.time;
        running = true;
    }
    public void EndState(){
        running = false;
    }
}
