using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShop : MonoBehaviour {
    public Text healthText, dammageText, shootSpeedText;

    public Text healthTextCurrent, dammageTextCurrent, shootSpeedTextCurrent;

    public Button healthButton, dammageButton, shootSpeedButton;

    public int costIncrese = 10;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    void UpdateGUI(){
        healthText.text = "BUY FOR " + GetCost("Health") + "$";
        dammageText.text = "BUY FOR " + GetCost("Dammage") + "$";
        shootSpeedText.text = "BUY FOR " + GetCost("Speed") + "$";

        healthTextCurrent.text = PlayerPrefs.GetInt("Health").ToString();
        dammageTextCurrent.text = PlayerPrefs.GetInt("Dammage").ToString();
        shootSpeedTextCurrent.text = PlayerPrefs.GetInt("Shoot").ToString();

        healthButton.onClick.AddListener(BuyHealth);
        dammageButton.onClick.AddListener(BuyDammage);
        shootSpeedButton.onClick.AddListener(ButSpeed);
    }

    void BuyHealth(){
        Buy("Health");
    }

    void BuyDammage(){
        Buy("Dammage");

    }

    void ButSpeed(){
        Buy("Speed");
    }
    int GetCost(string key){
        int value = PlayerPrefs.GetInt(key, 1);
        return value * costIncrese;
    }
    void Buy(string key){
        int money = PlayerPrefs.GetInt("Money", 0);
        int cost = GetCost(key);

        if(money <= cost){
            PlayerPrefs.SetInt("Money", money - cost);
            PlayerPrefs.SetInt(key, cost + 1);
        }
        UpdateGUI();
    }
}


