using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ICIndestructable : IColImpl
{
   
    public ICIndestructable(List<IConvertible> exceptions) : base(exceptions)
    {

    }

    public override void doOnEnter(GameObject source, Collider2D collider)
    {
        Boolean isDestroyed = false;
        GridObject go = collider.GetComponent<GridObject>();
        foreach (IConvertible i in exceptions)
        {
            if (go.type.Equals(i))
            {
                isDestroyed = true;
            }
        }
        if (isDestroyed)
        {
            UnityEngine.Object.Destroy(source);
        }
    }

    public override void doOnExit(GameObject source, Collider2D collider)
    {
   
    }

    public override void doOnStay(GameObject source, Collider2D collider)
    {
        
    }
}
