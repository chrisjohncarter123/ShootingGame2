using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public GameObject dammageObject;
    public GameObject[] failObjectsActivate;
    public GameObject[] failObjectsDeactivate;
    public GameObject deathObject;
    public bool useDammageObject = false;
    int maxHealth = 1;
    int currentHealth;

    public void SetMaxHealth(int val){
        this.maxHealth = val;
        ResetHealth();
    }
    // Use this for initialization
    void Start()
    {
        maxHealth = PlayerShop.GetHealth();
        currentHealth = maxHealth;

    }

    // Update is called once per frame
    void Update()
    {
        maxHealth = PlayerShop.GetHealth();
    }
    public float Percentage(){
        return currentHealth / maxHealth;
    }
    public void ResetHealth(){
        currentHealth = maxHealth;
    }
    public int GetCurrentHealth(){
        return currentHealth;
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Tirgger Enter " + other.name);
        if (other.GetComponent<Bullet>())
        {
            if (other.GetComponent<Bullet>().GetBulletType() == Bullet.BulletType.Enemy)
            {

                Debug.Log("Dammage " + other.name);

                int dammage = other.GetComponent<Bullet>().GetDammage();

                Dammage(dammage);
                if (useDammageObject)
                {
                    Instantiate(dammageObject, other.transform.position, dammageObject.transform.rotation);
                }
                Destroy(other);


            }

        }
    }



    public void Dammage(int dammage)
    {
        currentHealth -= dammage;

        if (currentHealth <= 0)
        {
            PlayerDeath();
        }
    }
    public bool GetIsAlive(){
        return currentHealth > 0; 
    }
    private void PlayerDeath()
    {
        Time.timeScale = 0;
        Debug.Log("Died");
        Instantiate(deathObject,transform.position, deathObject.transform.rotation);

        for (int i = 0; i < failObjectsActivate.Length; i++){
            failObjectsActivate[i].SetActive(true);
        }

        for (int i = 0; i < failObjectsDeactivate.Length; i++)
        {
            failObjectsDeactivate[i].SetActive(false);
        }
    }
}
