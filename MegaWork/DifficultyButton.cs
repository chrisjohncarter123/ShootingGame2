using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour {

    public int max = 100, min = 1;
    public Button increment, decrement;
    public Text text;
    public AudioSource clickSource;

	// Use this for initialization
	void Start () {
        increment.onClick.AddListener(ButtonIncrement);
        decrement.onClick.AddListener(ButtonDecrement);
        Set(0);                              
		
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}


    void ButtonDecrement(){
        Debug.Log("HI");
        Set(-1);
    }
    void ButtonIncrement(){
        Debug.Log("YO");
        Set(1);
    }

    void Set(int val){
        clickSource.Play();
        int current = PlayerPrefs.GetInt("Level");
        Debug.Log(current.ToString());

        if (current + val <= max && current + val >= min)
        {
            PlayerPrefs.SetInt("Level", current + val);
            text.text = PlayerPrefs.GetInt("Level").ToString();
        }





    }


}
