﻿using UnityEngine;
using System.Collections;
using System;

public class WeaponMissileIce : BaseMissile {
    public override void setType()
    {
        type = AssHandler.Weapons.IceMissile;
    }

}
