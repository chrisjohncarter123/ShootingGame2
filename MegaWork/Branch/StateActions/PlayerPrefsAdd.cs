using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsAdd : MonoBehaviour {

    public string key;
    public string value;
    public ValueType valueType;
    public SetType setType = SetType.SetEqual;

    public enum ValueType{
        Int,
        String,
        Float
    }

    public enum SetType{
        Add,
        SetEqual
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
//        Debug.Log(key + PlayerPrefs.GetInt(key, 0));
		
	}
    private void SetValue(int val){
        switch (setType){
            case SetType.Add:
                PlayerPrefs.SetInt(key, PlayerPrefs.GetInt(key, 0) + val);
                Debug.Log(name + " " + key + " added " + value);
                break;

            case SetType.SetEqual:
                PlayerPrefs.SetInt(key, val);
                Debug.Log(name + " " + key + " set to " + value);
                break;
        }
    }
    public void StartState()
    {
        switch(valueType) {
            case ValueType.Float:
                float floatValue = float.Parse(value, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
                PlayerPrefs.SetFloat(key, floatValue);
                break;
            case ValueType.Int:
                int intValue = Int32.Parse(value);
                SetValue(intValue);

                break;
            case ValueType.String:
                PlayerPrefs.SetString(key, value);
                break;
        }

    }

    public void EndState()
    {
        
    }
}
