using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract  class BaseMissile : GridObject
{
    public override void Initialize(Vector2 position, Vector2 size)
    {
        base.speed = 0.05f;
        base.setParams(position, size);
    }
 
    //Prevents destroying the player on spawn
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
          
            exc.Add(AssHandler.Decorators.Explosion);
            base.setCollisionBehaviour(new ICDestructable(exc));
        }
        base.OnTriggerExit2D(col);
    }
}
