using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ICExplode : IColImpl {
    private bool isExploded = false;

    public ICExplode(List<IConvertible> exceptions) : base(exceptions)
    {
    }

    public override void doOnEnter(GameObject source, Collider2D collider)
    {
        Boolean isDestroyed = true;
        GridObject go = collider.GetComponent<GridObject>();
        foreach (IConvertible i in exceptions)
        {
            if (go.type.Equals(i))
            {
                isDestroyed = false;
            }
        }
        if (isDestroyed)
        {
            Vector3 pos = source.transform.localPosition;
            Vector3 size = source.transform.localScale;
            GameObject g = AssHandler.Instantiate(AssHandler.Decorators.Explosion);
            g.transform.parent = GameManager.getGameManager().getLevelHolder().transform;
            g.GetComponent<GridObject>().Initialize(pos, size);
            g.transform.localPosition = new Vector3(pos.x,pos.y,1);
            isExploded = true;
            UnityEngine.Object.Destroy(source);
        }
    }

    public override void doOnExit(GameObject source, Collider2D collider)
    {
    
    }

    public override void doOnStay(GameObject source, Collider2D collider)
    {
        Debug.Log(source.name);
    }
    
}
