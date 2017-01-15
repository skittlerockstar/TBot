using UnityEngine;
using System.Collections;
using System;

public class WeaponMissileNormal : BaseMissile {
    public override void setType()
    {
        type = AssHandler.Weapons.NormalMissile;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
