using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCurveMover : MonoBehaviour {
    [SerializeField]
    int n;
    [SerializeField]
    float minM, maxM, minF, maxF, minS, maxS;

    [SerializeField]
    float xMult = 1, yMult = 0, zMult = 1;

    RandomCurve3 randomCurve;
    float time;

	// Use this for initialization
	void Start () {
        randomCurve = new RandomCurve3(n, minM, maxM, minF, maxF, minS, maxS);
		
	}
	
    void FixedUpdate()
    {

        time += Time.deltaTime;
        Vector3 c = randomCurve.Value(time);

        transform.position += new Vector3(c.x * xMult, c.y * yMult, c.z * zMult);

    }
}
