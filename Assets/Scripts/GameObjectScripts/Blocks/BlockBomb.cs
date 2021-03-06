﻿using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BlockBomb : BaseCrate {

    public override void Initialize(Vector2 position,Vector2 size)
    {
        base.Initialize(position, size);
       
        exc.Add(AssHandler.Weapons.IceMissile);
        setCollisionBehaviour(new ICFreezable(null));
        setCollisionBehaviour(new ICExplode(exc),false);

    }

    public override void setType()
    {
        type = AssHandler.Blocks.Bomb;
    }
}
