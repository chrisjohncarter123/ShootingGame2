using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour {


    public Transform target;
    public string targetTag;
    public float speed = .1f;

	// Use this for initialization
	void Start () {
        if (!target){
            target = GameObject.FindWithTag(targetTag).transform;
        }
	}
	
	// Update is called once per frame
	void Update () {
        
        transform.LookAt(target);
		
	}
}
