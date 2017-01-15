using UnityEngine;
using System.Collections;
using System;

public abstract class BaseCrate : GridObject {

   // public CollisionBehaviour collisionBehaviour;
    public override void Initialize(Vector2 position, Vector2 size)
    {
        setCollisionBehaviour(new ICDestructable(null));
        base.setParams(position, size);
    }
  

    
}
