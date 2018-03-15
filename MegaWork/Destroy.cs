using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public float time;
    float destroyTime;
	// Use this for initialization
	void Start () {
        destroyTime = Time.time + time;;
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Time.time >= destroyTime){
            Destroy(gameObject);
        }
	}
}
