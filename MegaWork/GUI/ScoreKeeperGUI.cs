using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeperGUI : MonoBehaviour {


    public Text score, wave, money;
    public string scorePrefix, wavePrefix, moneyPrefix;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(score)
            score.text = scorePrefix + PlayerPrefs.GetInt("Score", 0).ToString();
        if(wave)
            wave.text = wavePrefix + PlayerPrefs.GetInt("Wave", 1).ToString();
        if(money)
            money.text = moneyPrefix + PlayerPrefs.GetInt("Wave", 1).ToString();
	}
}
