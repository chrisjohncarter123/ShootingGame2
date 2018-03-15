using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopPurchasableGUI : MonoBehaviour {

    public Text purchasableName, description;
    public Button purchaseButton, equipButton, unequipButton;

    ShopPurchasable purchasable;
	// Use this for initialization
	void Start () {
        purchaseButton.onClick.AddListener(Purchase);
       // equipButton.onClick.AddListener(Equip);


        if(purchasableName)
            purchasableName.text = purchasable.purchasableName;
        
        if (description)
        description.text = purchasable.description;
		
	}

    // Update is called once per frame
    void Update()
    {


        if (purchasable.IsPurchased())
        {
            if (purchasable.IsEquiped())
            {
                SetEquiped();
            }
            else
            {
                SetUnequiped();
            }
        }

        else
        {
            SetUnpurchased();
        }
	}
    public void SetShopPurchasable(ShopPurchasable purchasable){
        this.purchasable = purchasable;
    }

    void Purchase(){
        if(PlayerPrefs.GetInt("Money", 0) >= purchasable.moneyCost){
            PlayerPrefs.SetInt("Money", PlayerPrefs.GetInt("Money") - purchasable.moneyCost);
            purchasable.settings.Purchase(purchasable);
        }


    }
    void Equip(){
        purchasable.settings.Equip(purchasable);
    }

    void SetUnpurchased(){
        purchaseButton.gameObject.SetActive(true);
        unequipButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(false);
    }
    void SetEquiped(){
        purchaseButton.gameObject.SetActive(false);
        unequipButton.gameObject.SetActive(true);
        equipButton.gameObject.SetActive(false);
        purchasable.Equip();
    }
    void SetUnequiped(){
        purchaseButton.gameObject.SetActive(false);
        unequipButton.gameObject.SetActive(false);
        equipButton.gameObject.SetActive(true);
        purchasable.Unequip();
    }

}
