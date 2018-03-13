using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotBuilder : MonoBehaviour {

    public GameObject[] bodies;
    public GameObject[] eyes;
    public GameObject[] mouths;
    public GameObject[] noses;
    public GameObject[] movers;

    public float creationRadiusX = 4;
    public float creationRadiusY = 4;

    public Transform robotStartingPosition;


	// Use this for initialization
	void Start () {

        for (int i = 0; i < 20; i++){
            BuildRobot();
        }
        
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void RandomizeStartingPosition(){
        robotStartingPosition.position =
                                 robotStartingPosition.position +
                                 new Vector3(
                                     Random.insideUnitCircle.x * creationRadiusX,
                                     Random.insideUnitCircle.y * creationRadiusY, 0);
    }
    public void BuildRobot(){



        RandomizeStartingPosition();

        GameObject mover = Instantiate(
            movers[Random.Range(0, movers.Length)],
            robotStartingPosition.position,
            robotStartingPosition.rotation);

        int bodyIndex = Random.Range(0, bodies.Length);
        GameObject body = Instantiate(
            bodies[bodyIndex],
            robotStartingPosition.position,
            bodies[bodyIndex].transform.rotation);
        
        body.transform.parent = mover.transform;
        RobotBody robotBody = body.GetComponent<RobotBody>();


        GameObject eye = Instantiate(eyes[Random.Range(0, eyes.Length)], robotBody.eyesPosition.position, robotBody.eyesPosition.rotation);
        eye.transform.parent = robotBody.eyesPosition;
        GameObject nose = Instantiate(noses[Random.Range(0, noses.Length)], robotBody.nosePosition.position, robotBody.nosePosition.rotation);
        nose.transform.parent = robotBody.nosePosition;
        GameObject mouth = Instantiate(mouths[Random.Range(0, mouths.Length)], robotBody.mouthPosition.position, robotBody.mouthPosition.rotation);
        mouth.transform.parent = robotBody.mouthPosition;

    }
}
