using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    StateBranch stateBranch;


    public void SetBranch(StateBranch stateBranch){
        this.stateBranch = stateBranch;
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SendMessageToBranch(string message){
        stateBranch.SendMessage(message);
    }
}
