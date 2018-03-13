using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCurveMover : MonoBehaviour {
    [SerializeField]
    int n;
    [SerializeField]
    float minM, maxM, minF, maxF, minS, maxS;

    RandomCurve3 randomCurve;
    float time;

	// Use this for initialization
	void Start () {
        randomCurve = new RandomCurve3(n, minM, maxM, minF, maxF, minS, maxS);
		
	}
	
    void FixedUpdate()
    {

        time += Time.deltaTime;

        transform.position += randomCurve.Value(time);

    }
}
