using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : GridObject
{
    public override void Initialize(Vector2 position, Vector2 size)
    {
        base.setParams(position, size);
    }

    public override void setType()
    {
        type = AssHandler.PowerUps.FireMissile;
        setCollisionBehaviour(new ICDestructable(null));
    }

}
