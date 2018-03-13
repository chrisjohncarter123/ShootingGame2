using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMover : MonoBehaviour {
    public Vector3 magnitude;



    // Update is called once per frame
    void FixedUpdate()
    {

        transform.position += magnitude * Time.deltaTime;

    }
}
