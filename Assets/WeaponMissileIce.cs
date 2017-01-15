using UnityEngine;
using System.Collections;
using System;

public class WeaponMissileIce : BaseMissile {
    public override void setType()
    {
        type = AssHandler.Weapons.IceMissile;
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
