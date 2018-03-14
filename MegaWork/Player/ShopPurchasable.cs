using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPurchasable : MonoBehaviour {

    public int moneyCost = 1000;
    public string purchasableName, description;
    public GameObject weapon;
    public ShopSettings settings;
    public AudioSource equipSound;

    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public bool IsPurchased(){
        return PlayerPrefs.GetInt(purchasableName, 0) == 1;
    }
    public bool IsEquiped()
    {
        return settings.GetEquiped().Equals(this);
    }
    public void InitShopPurchasable(ShopSettings settings){

        this.settings = settings;
        GameObject gui = GameObject.Instantiate(settings.guiObject);
        gui.transform.parent = settings.guiObjectParent;
        gui.GetComponent<ShopPurchasableGUI>().SetShopPurchasable(this);
    }


    public void Equip()
    {
        weapon.SetActive(true);

        if(equipSound)
        {
            equipSound.Play();
        }
    }
    public void Unequip(){
        weapon.SetActive(false);
    }

}
