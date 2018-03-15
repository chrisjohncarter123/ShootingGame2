using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {


    [SerializeField]
    int dammage = 1;

    public enum BulletType {
        Player,
        Enemy
    }

    public enum DammageType{
        Iron,
        Pizza
    }

    [SerializeField]
    BulletType bulletType = BulletType.Enemy;

    [SerializeField]
    DammageType dammageType = DammageType.Iron;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public DammageType GetDammageType(){
        return dammageType;
    }
    public BulletType GetBulletType(){
        return bulletType;
    }

    public void SetDammage(int dammage){
        this.dammage = dammage;
    }
    public int GetDammage(){
        return dammage;
    }





    public float distance = 1000;
    public Vector3 magnitude;
    public MoveType moveType = MoveType.Global;

    public enum MoveType
    {
        Relative,
        Global
    }

}
