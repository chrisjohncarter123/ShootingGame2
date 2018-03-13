using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateStarter : MonoBehaviour {

    public StateBranch branch;

	// Use this for initialization
	void Start () {
        branch.StartBranch();

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
