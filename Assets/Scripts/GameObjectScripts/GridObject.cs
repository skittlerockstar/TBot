using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class GridObject : MonoBehaviour,IInstantiate{
    public static UnityEngine.Object prefab;
    protected Vector2 gridPos;
    public Vector2 size;
    public System.IConvertible type ;
    public ICollisionBehaviour collisionBehaviour = new ICIndestructable(null);
    public List<IConvertible> exc = new List<IConvertible>();
    public virtual void init()
    {
        setType();
        GridHandler.resizeObject(gameObject);
        GridHandler.placeObjectAt(gameObject, gridPos, size);
        
        if(type == null)
        { 
            throw new NullReferenceException("Type is not set for " + gameObject.name);
        }
    }
    protected void setParams(Vector2 pos,Vector2 size)
    {
        this.gridPos = pos;
        this.size = size;
        init();
    }
    public void setCollisionBehaviour(ICollisionBehaviour behaviour)
    {
        collisionBehaviour = behaviour;
    }
    public abstract void Initialize(Vector2 position, Vector2 size);
    public abstract void setType();
    void OnTriggerEnter2D(Collider2D col)
    {
        collisionBehaviour.doOnEnter(gameObject,col);
    }
    protected void OnTriggerExit2D(Collider2D col)
    {
        collisionBehaviour.doOnExit(gameObject, col);
    }
    void OnTriggerStay2D(Collider2D col)
    {
        collisionBehaviour.doOnStay(gameObject, col);
    }

}
