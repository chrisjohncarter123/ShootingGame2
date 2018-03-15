using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMover : MonoBehaviour {
    public Vector3 magnitude;
    public MoveType moveType = MoveType.Global;

    public enum MoveType{
        Relative,
        Global
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 moveAdd = magnitude * Time.deltaTime;
        if (moveType == MoveType.Global)
        {
            transform.position += moveAdd;
        }
        else if (moveType == MoveType.Relative) {
            transform.position +=
                         moveAdd.z * transform.forward +
                         moveAdd.x * transform.right +
                         moveAdd.y * transform.up;
                
        }

    }
}
