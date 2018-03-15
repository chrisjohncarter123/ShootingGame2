using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShop : MonoBehaviour {
    public Text healthText, dammageText, shootSpeedText;

    public Text healthTextCurrent, dammageTextCurrent, shootSpeedTextCurrent;

    public Button healthButton, dammageButton, shootSpeedButton;

    public string buyPrefix = "";

    public int costIncrese = 10;

    public AudioSource healthSound, dammageSound, speedSound;

    static int health, dammage, speed;

    static bool inited = false;

    static PlayerShop shop;

    public PlayerHealth playerHealth;

	// Use this for initialization
	void Start () {
        healthButton.onClick.AddListener(BuyHealth);
        dammageButton.onClick.AddListener(BuyDammage);
        shootSpeedButton.onClick.AddListener(ButSpeed);
        shop = this;
        UpdateGUI();
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    public static int GetDammage(){
        if(!inited){
            shop.UpdateGUI();
        }
        return dammage;
    }
    public static int GetHealth(){
        if (!inited)
        {
            shop.UpdateGUI();
        }
        return health;
    }
    public static int GetSpeed(){
        if (!inited)
        {
            shop.UpdateGUI();
        }
        return speed;
    }

    public void UpdateGUI(){
        inited = true;
        healthText.text = buyPrefix + GetCost("Health") + "$";
        dammageText.text = buyPrefix + GetCost("Dammage") + "$";
        shootSpeedText.text = buyPrefix + GetCost("Speed") + "$";

        health = PlayerPrefs.GetInt("Health", 5);
        dammage = PlayerPrefs.GetInt("Dammage", 1);
        speed = PlayerPrefs.GetInt("Speed", 1);

        healthTextCurrent.text = health.ToString();
        dammageTextCurrent.text = dammage.ToString();
        shootSpeedTextCurrent.text = speed.ToString();

        shop.playerHealth.SetMaxHealth(health);

    }

    void BuyHealth(){
        Buy("Health", healthSound);
    }
    void BuyDammage(){
        Buy("Dammage", dammageSound);
    }
    void ButSpeed(){
        Buy("Speed", speedSound);
    }
    int GetCost(string key){
        int value = PlayerPrefs.GetInt(key, 1);
        return value * costIncrese;
    }
    void Buy(string key, AudioSource audio){
        
        int money = PlayerPrefs.GetInt("Money", 0);
        int cost = GetCost(key);

        Debug.Log(money + " " + cost);

        if(money >= cost){
            PlayerPrefs.SetInt("Money", money - cost);
            PlayerPrefs.SetInt(key, cost + 1);
            audio.Play();

        }
        UpdateGUI();
    }
}


