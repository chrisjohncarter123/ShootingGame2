using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateBranch : MonoBehaviour {

    int currentState = 0;

	// Use this for initialization
	void Awake () {
        for (int i = 0; i < GetStates().Length; i++){
            GetStates()[i].SetBranch(GetComponent<StateBranch>());
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    State[] GetStates()
    {
        return GetComponentsInChildren<State>();
    }
    private void StartCurrentState(){
        GetStates()[currentState].SendMessage("StartState");
    }
    private void EndCurrentState(){
        GetStates()[currentState].SendMessage("EndState");
    }
    public void StartBranch(){
        currentState = 0;
        StartCurrentState();
    }

    public void NextState(){
        EndCurrentState();
        if (currentState + 1 >= GetStates().Length)
        {
           // Debug.Log("State finish " + name);
        }
        else
        {
            currentState += 1;
            StartCurrentState();
           
        }
    }
}
