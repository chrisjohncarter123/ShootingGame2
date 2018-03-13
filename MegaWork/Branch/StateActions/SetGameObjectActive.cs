using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGameObjectActive : MonoBehaviour {

    public GameObject[] gameObjects;
    public bool value;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartState()
    {
        for (int i = 0; i < gameObjects.Length; i++){
            gameObjects[i].SetActive(value);
        }
    }
    public void EndState()
    {

    }
}
