using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockArrow : BaseCrate
{
    public override void Initialize(Vector2 position, Vector2 size) { 
        base.Initialize(position, size);
        setCollisionBehaviour(new ICNothing(null));
    }
    public override void setType()
    {
        type = AssHandler.Blocks.Arrow;
    }

     void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

           Quaternion q =  gameObject.transform.localRotation;
            gameObject.transform.localRotation =  Quaternion.Euler(new Vector3(0, 0, q.eulerAngles.z -90));
            if (direction == movementDir.Left) { direction = movementDir.Up; }
            else { direction++; }
            
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.transform.localPosition = gameObject.transform.localPosition;
        col.gameObject.transform.localRotation = gameObject.transform.localRotation;
        GridObject g =  col.gameObject.gameObject.GetComponent<GridObject>();
        g.direction = direction;
    }
}
