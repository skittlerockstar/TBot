using UnityEngine;
using System.Collections;
using System;

public class WeaponMissileFire : BaseMissile
{
    public override void setType()
    {
        type = AssHandler.Weapons.FireMissile;
    }
}
