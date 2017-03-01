using System;
using System.Collections.Generic;
using UnityEngine;

public class ICFreezable : IColImpl
{
    private List<IConvertible> exc;
    Boolean frozen = false;
    public ICFreezable(List<IConvertible> exc) : base(exc)
    {
        this.exc = exc;
    }

    public override void doOnEnter(GameObject source, Collider2D collider)
    {
        if (!getType(collider.gameObject).Equals(AssHandler.Weapons.IceMissile)) return;
        if (!frozen)
        {
            Debug.Log("test");
            frozen = true;
            getGridO(source).removeCollisionBehaviour(typeof(ICExplode));
            getGridO(source).setCollisionBehaviour(new ICDestructable(null));
           
            UnityEngine.GameObject s = UnityEngine.Object.Instantiate(Resources.Load("Prefabs/Blocks/freeze"),source.transform) as GameObject;
            s.transform.localScale = s.transform.localScale * 4;
            s.GetComponent<SpriteRenderer>().sortingOrder = 1;

        }
    }

    public override void doOnExit(GameObject source, Collider2D collider)
    {
      
    }

    public override void doOnStay(GameObject source, Collider2D collider)
    {
       
    }
}