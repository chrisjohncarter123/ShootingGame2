using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetText : MonoBehaviour {


    public Text text;
    public bool setText = true;
    public string newText;
    public bool setFont = true;
    public Font newFont;
    public bool setColor = true;
    public Color newColor;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void StartState()
    {
        if(setText)
            text.text = newText;

        if(setColor)
            text.color = newColor;

        if(setFont)
            text.font = newFont;
        

    }
    public void EndState()
    {
    }
    
}
