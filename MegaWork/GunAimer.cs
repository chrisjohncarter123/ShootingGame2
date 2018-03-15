using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAimer : MonoBehaviour {
    Vector3 startingRotation;
 
	// Use this for initialization
	void Start () {
        startingRotation = transform.localEulerAngles;
		
	}
	
	// Update is called once per frame
	void Update () {
        Aim();
	}

    void Aim(){
        float screenX = Screen.width / 2;
        float screenY = Screen.height / 2;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(screenX, screenY));

        bool rotate = false;
        if(Physics.Raycast(ray, out hit)){

            if (hit.collider.gameObject.GetComponent<RobotBody>())
            {
                rotate = true;

            }
        }

        if(rotate){
            transform.LookAt(hit.point);
        }
        else {
            transform.localEulerAngles = startingRotation;
        }
    }
}
