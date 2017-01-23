using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public abstract class GridObject : MonoBehaviour,IInstantiate{
    public static UnityEngine.Object prefab;
    public enum movementDir { Up,Right,Down,Left};
    protected Vector2 gridPos;
    public Vector2 size;
    public float speed = 0.0f;
    public movementDir direction = movementDir.Up;
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
    private void FixedUpdate()
    {
        moveObject();
    }

    private void moveObject()
    {
        Vector3 movement = new Vector3(0, 0);
        switch (direction)
        {
            case movementDir.Up: movement = new Vector3(0, speed); break;
            case movementDir.Right: movement = new Vector3(speed,0); break;
            case movementDir.Left: movement = new Vector3(-speed, 0); break;
            case movementDir.Down: movement = new Vector3(0, -speed);  break;
        }
        gameObject.transform.localPosition += movement;
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
