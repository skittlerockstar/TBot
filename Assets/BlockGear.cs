using UnityEngine;
using System.Collections;
using System;

public class BlockGear : BaseCrate
{
    public override void Initialize(Vector2 position, Vector2 size)
    {
        base.Initialize(position, size);
        setCollisionBehaviour(new ICDestructable(null));
    }
    public override void setType()
    {
        type = AssHandler.Blocks.Part;
    }
    void OnDestroy()
    {
        //lose game;

    }
}
