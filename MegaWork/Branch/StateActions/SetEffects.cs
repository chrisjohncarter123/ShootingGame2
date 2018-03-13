using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetEffects : MonoBehaviour {


    public Material skyboxMaterial;
    public Color ambientSkyColor;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void StartState()
    {
        RenderSettings.skybox = skyboxMaterial;
        RenderSettings.ambientSkyColor = ambientSkyColor;
    }
    public void EndState()
    {
        
    }
}
