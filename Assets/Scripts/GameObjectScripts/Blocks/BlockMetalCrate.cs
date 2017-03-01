using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class BlockMetalCrate : BaseCrate
{
    public override void Initialize(Vector2 position,Vector2 size)
    {
        base.Initialize(position, size);
       
        exc.Add(AssHandler.Decorators.Explosion);
        exc.Add(AssHandler.Weapons.FireMissile);

        setCollisionBehaviour(new ICIndestructable(exc));
    }

    public override void setType()
    {
        type = AssHandler.Blocks.MetalCrate;
    }
}
