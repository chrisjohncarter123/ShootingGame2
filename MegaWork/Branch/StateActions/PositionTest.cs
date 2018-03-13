using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionTest : MonoBehaviour {


    public Transform testObject;
    public float minHeight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(testObject.position.y < minHeight) {
            GetComponent<State>().SendMessageToBranch("NextState");

        }
	}


    public void StartState()
    {
        
    }
    public void EndState()
    {
        
    }
}
