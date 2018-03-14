using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSettings : MonoBehaviour {

    public ShopPurchasable initialEquiped;
    public List<ShopPurchasable> purchasables;
    public GameObject guiObject;
    public Transform guiObjectParent;
    ShopPurchasable equiped;

    public ShopPurchasable GetEquiped(){
        return equiped;
    }
	// Use this for initialization
	void Start () {

        for (int i = 0; i < purchasables.Count; i++){
            purchasables[i].InitShopPurchasable(this);
        }
        UnequipAll();

        Equip(initialEquiped);
	}


	// Update is called once per frame
	void Update () {
		
	}
    public void Purchase(ShopPurchasable purchasable){
        PlayerPrefs.SetInt(purchasable.purchasableName, 1);
    }
    public void Equip(ShopPurchasable purchasable){

        if (equiped)
        {
            equiped.Unequip();
        }
        equiped = purchasable;
        equiped.Equip();
       
    }
    public void UnequipAll(){

        for (int i = 0; i < purchasables.Count; i++)
        {
            purchasables[i].Unequip();
        }
        
    }
}
