using UnityEngine;
using System.Collections;
using System;

public class BlockCrate : BaseCrate
{
    public override void Initialize(Vector2 position, Vector2 size)
    { 
        base.Initialize(position, size);
        setCollisionBehaviour(new ICDestructable(null), true);
    }
    public override void setType()
    {
        type = AssHandler.Blocks.Crate;
    }
}
