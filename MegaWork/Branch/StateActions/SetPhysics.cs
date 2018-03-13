using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPhysics : MonoBehaviour {


    public float timeScale;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartState()
    {
        Time.timeScale = timeScale;
    }
    public void EndState()
    {
        
    }
}
