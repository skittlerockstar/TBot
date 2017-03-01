using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockArrow : BaseCrate, IClickable
{
    public override void Initialize(Vector2 position, Vector2 size) {
        setCollisionBehaviour(new ICNothing(null), true);
        base.Initialize(position, size);
    }
    public override void setType()
    {
        type = AssHandler.Blocks.Arrow;
    }

     void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            rotateArrow();
        }
    }

    private void rotateArrow()
    {
        Quaternion q = gameObject.transform.localRotation;
        gameObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, q.eulerAngles.z - 90));
        if (direction == movementDir.Left) { direction = movementDir.Up; }
        else { direction++; }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.GetComponent<GridObject>() is BaseMissile)
        {
            col.gameObject.transform.localPosition = gameObject.transform.localPosition;
            col.gameObject.transform.localRotation = gameObject.transform.localRotation;
            GridObject g = col.gameObject.gameObject.GetComponent<GridObject>();
            g.direction = direction;
        }
    }
    public override void OnRayEnter()
    {
        Debug.Log(" ro");
        rotateArrow();
    }
}
