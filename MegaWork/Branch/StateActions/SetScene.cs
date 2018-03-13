using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetScene : MonoBehaviour {


    public string scene;
    public LoadSceneMode loadSceneMode;
    public Action action;

    public enum Action {
        LoadScene,
        UnloadScene
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartState()
    {
//        Debug.Log("set scene");
        if(action == Action.LoadScene) {
            SceneManager.LoadScene(scene, loadSceneMode);
        }
        else if (action == Action.UnloadScene) {
            SceneManager.UnloadSceneAsync(scene);
        }
    }
    public void EndState()
    {

    }
}
