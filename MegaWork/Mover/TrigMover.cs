using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigMover : MonoBehaviour {

    public Vector2 magnitude;
    public Vector2 frequency;

    float time;

	// Use this for initialization
	void Start () {
        time = 0;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        time += Time.deltaTime;

        transform.position += new Vector3(
            magnitude.x * Mathf.Cos(time * frequency.x),
            magnitude.y * Mathf.Sin(time * frequency.y),
            0
            );
		
	}
}
