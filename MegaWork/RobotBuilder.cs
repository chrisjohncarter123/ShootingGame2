using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RobotBuilder : MonoBehaviour {

    public GameObject[] bodies;
    public GameObject[] eyes;
    public GameObject[] mouths;
    public GameObject[] noses;
    public GameObject[] movers;
    public GameObject[] shooters;

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

    private Vector3 RandomizeStartingPosition(){

        Vector2 circle = Random.insideUnitCircle;
        circle.x *= creationRadiusX;
        circle.y *= creationRadiusY;
        circle.x += robotStartingPosition.position.x;
        circle.y += robotStartingPosition.position.y;
        return new Vector3(circle.x, circle.y, 0);
    }
    public void BuildRobot(){




        GameObject mover = Instantiate(
            movers[Random.Range(0, movers.Length)],
            RandomizeStartingPosition(),
            Quaternion.identity);
        Debug.Log(mover.transform.position);

        int bodyIndex = Random.Range(0, bodies.Length);
        GameObject body = Instantiate(
            bodies[bodyIndex]);

        body.transform.localPosition = Vector3.zero;
        
        body.transform.parent = mover.transform;
        RobotBody robotBody = body.GetComponent<RobotBody>();
        robotBody.SetRobotParent(mover);

        GameObject eye = Instantiate(eyes[Random.Range(0, eyes.Length)], robotBody.eyesPosition.position, robotBody.eyesPosition.rotation);
        eye.transform.parent = robotBody.eyesPosition;
        GameObject nose = Instantiate(noses[Random.Range(0, noses.Length)], robotBody.nosePosition.position, robotBody.nosePosition.rotation);
        nose.transform.parent = robotBody.nosePosition;
        GameObject mouth = Instantiate(mouths[Random.Range(0, mouths.Length)], robotBody.mouthPosition.position, robotBody.mouthPosition.rotation);
        mouth.transform.parent = robotBody.mouthPosition;
        GameObject shooter = Instantiate(shooters[Random.Range(0, shooters.Length)], robotBody.shooterPosition.position, robotBody.shooterPosition.rotation);
        shooter.transform.parent = robotBody.shooterPosition;

    }
}
