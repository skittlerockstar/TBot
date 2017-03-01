using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class IColImpl : ICollisionBehaviour
{
    protected List<IConvertible> exceptions;
    public IColImpl(List<IConvertible> exceptions)
    {
       // Debug.Log(exceptions.Count);
        if (exceptions != null)
        { 
            this.exceptions = exceptions;
        }else
        {
            this.exceptions = new List<IConvertible>();
        }
    }
    public IConvertible getType(GameObject go)
    {
        GridObject gob = go.GetComponent<GridObject>();
        return gob.type;
    }
    public GridObject getGridO(GameObject go)
    {
        GridObject gob = go.GetComponent<GridObject>();
        return gob;
    }
    public abstract void doOnEnter(GameObject source, Collider2D collider);
    public abstract void doOnExit(GameObject source, Collider2D collider);
    public abstract void doOnStay(GameObject source, Collider2D collider);
}
