using UnityEngine;
using System.Collections;
using System;

public abstract class BaseCrate : GridObject {

   // public CollisionBehaviour collisionBehaviour;
    public override void Initialize(Vector2 position, Vector2 size)
    {
        exc.Add(AssHandler.Blocks.Arrow);
        setCollisionBehaviour(new ICIndestructable(exc));
        base.setParams(position, size);
        gridHand.resetHitBox(gameObject, new Vector2(0.9f, 0.9f));
    }
  

    
}
