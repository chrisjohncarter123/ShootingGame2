using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsAdd : MonoBehaviour {

    public string key;
    public string value;
    public ValueType valueType;

    public enum ValueType{
        Int,
        String,
        Float
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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
                PlayerPrefs.SetInt(key, intValue);
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
