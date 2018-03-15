using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSettings : MonoBehaviour {

    public ShopPurchasable initialEquiped;
    public List<ShopPurchasable> purchasables;
    public GameObject guiObject;
    public Transform guiObjectParent;
    public PlayerShooter playerShooter;
    public bool createGUIElements = false;

    ShopPurchasable equiped;

    public ShopPurchasable GetEquiped(){
        return equiped;
    }
	// Use this for initialization
	void Start () {
        if (createGUIElements)
        {
            for (int i = 0; i < purchasables.Count; i++)
            {
                purchasables[i].InitShopPurchasable(this);
            }
        }
        UnequipAll();
        if(!PlayerPrefs.HasKey(initialEquiped.purchasableName))
        {
            Purchase(initialEquiped);
        }

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
        playerShooter.gun = purchasable.weapon.GetComponent<Gun>();
       
    }
    public void UnequipAll(){

        for (int i = 0; i < purchasables.Count; i++)
        {
            purchasables[i].Unequip();
        }
        
    }
}
