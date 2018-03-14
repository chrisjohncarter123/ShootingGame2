using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateGoIfPlayerPref : MonoBehaviour {

    public string key, value;
    public bool startOwn = false;
    public PlayerPrefsAdd.ValueType valueType;
    public Condition condition;
    public enum Condition{
        Equals,
        LessThan,
        GreaterThan
    }

    bool isOn = false;

	// Use this for initialization
	void Start () {
        if(valueType == PlayerPrefsAdd.ValueType.Float){
            Debug.LogError("Float value type not supported for StateGoIfPlayerPref.");
        }
       
        if(startOwn){
            isOn = true;
        }
	}
	
	// Update is called once per frame
	void StartState () {
        isOn = true;
	}
    public void EndState()
    {
        isOn = false;
    }

    void Update()
    {




        if(!isOn)
        {
            return;
        }
        if (valueType == PlayerPrefsAdd.ValueType.Float)
        {
            return;
        }
        Debug.Log(key + "(" + PlayerPrefs.GetInt(key) + ") Compared to " + value);
        if(TestCondition(PlayerPrefs.GetInt(key), Int32.Parse(value))){
            
            GetComponent<State>().SendMessageToBranch("NextState");
            EndState();
        }


    }
    bool TestCondition(int val, int compare){

        switch (condition)
        {
            case Condition.Equals:

                return (val == compare);

                break;

            case Condition.GreaterThan:

                return (val > compare);

                break;

            case Condition.LessThan:

                return (val < compare);

                break;

        }

        return false;
    }
    void Test(){
        if (PlayerPrefs.HasKey(key))
        {
            switch (valueType)
            {

                case PlayerPrefsAdd.ValueType.Int:

                    int intValue = Int32.Parse(value);
                    int playerPrefsIntValue = PlayerPrefs.GetInt(key);
                    if (TestCondition(intValue, playerPrefsIntValue))
                    {
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

}
