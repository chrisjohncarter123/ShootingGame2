using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGoIfPlayerPref : MonoBehaviour {

    public string key, value;

    public PlayerPrefsAdd.ValueType valueType;




	// Use this for initialization
	void Start () {
        if(valueType == PlayerPrefsAdd.ValueType.Float){
            Debug.LogError("Float value type not supported for StateGoIfPlayerPref.");
        }
       
		
	}
	
	// Update is called once per frame
	void StartState () {
		
	}

    void Update()
    {
        if (valueType == PlayerPrefsAdd.ValueType.Float)
        {
            return;
        }


        if(PlayerPrefs.HasKey(key)) {
            switch (valueType)
            {
  
                case PlayerPrefsAdd.ValueType.Int:
                    int intValue = Int32.Parse(value);
                    int playerPrefsIntValue = PlayerPrefs.GetInt(key);
                    if(intValue == playerPrefsIntValue){
                        GetComponent<State>().SendMessageToBranch("NextState");
                        EndState();
                    }
                    break;
                case PlayerPrefsAdd.ValueType.String:
                    //PlayerPrefs.SetString(key, value);
                    string playerPrefsStringValue = PlayerPrefs.GetString(key);
                    Debug.Log("here");
                    if (value.Equals(playerPrefsStringValue))
                    {
                        Debug.Log("here2");
                        GetComponent<State>().SendMessageToBranch("NextState");
                        EndState();
                    }
                    break;
            }
        }

    }
    public void EndState()
    {

    }
}
