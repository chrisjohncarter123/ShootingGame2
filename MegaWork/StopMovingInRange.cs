using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMovingInRange : MonoBehaviour {
    public float zPosMax, zPosMin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(transform.position.z > zPosMax || transform.position.z < zPosMin){
            GetComponent<LinearMover>().magnitude = Vector3.zero;
            Destroy(this);
        }
		
	}
}
