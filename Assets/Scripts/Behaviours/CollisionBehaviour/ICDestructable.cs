using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class ICDestructable : IColImpl
{
    
    public ICDestructable(List<IConvertible> exceptions) : base(exceptions)
    {
        
    }

    public override void doOnEnter(GameObject source, Collider2D collider)
    {
        Boolean isDestroyed = true;
       
        GridObject go = collider.GetComponent<GridObject>();
        Debug.Log(go.collisionBehaviour);
        foreach (IConvertible i in exceptions)
        {
            if (go.type.Equals(i))
            {
                isDestroyed = false;
            }
        }
        if(go.collisionBehaviour.GetType() ==  typeof(ICNothing))
        {
            isDestroyed = false;
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
