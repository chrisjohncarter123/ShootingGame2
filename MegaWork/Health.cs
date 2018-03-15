using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {



    public int maxLife;

    int currentLife;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void TakeDammage(int dammage){
        currentLife -= dammage;

        if(currentLife <= 0) {
            gameObject.SendMessage("Died");
        }
    }

}
