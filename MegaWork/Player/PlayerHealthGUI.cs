using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthGUI : MonoBehaviour {

    public Text healthText;
    public PlayerHealth health;
    public string prefix, suffix;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        healthText.text = prefix + (int)(health.Percentage() * 100) + suffix;
		
	}
}
