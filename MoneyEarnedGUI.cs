using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyEarnedGUI : MonoBehaviour {

    public string prefix, suffix;
    public Text text;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        text.text = prefix + RobotBody.GetTotalMoneyEarnedThisWave() + suffix;
		
	}
}
