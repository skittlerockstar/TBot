using UnityEngine;
using System.Collections;
using System;

public class BlockGear : BaseCrate
{
    bool destroyed = false;
    public override void Initialize(Vector2 position, Vector2 size)
    {
        base.Initialize(position, size);
        setCollisionBehaviour(new ICIndestructable(null));
        gameMan.getLevelManager().loseCriteria.addCriteria(() => destroyed);
        gameMan.getLevelManager().addPart();
        gameMan.getUIHandler().addPart();
    }
    public override void setType()
    {
        type = AssHandler.Blocks.Part;
    }
    void OnDestroy()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //TODO if hit by missile, collect. else , lose game
        GridObject go = collision.gameObject.GetComponent<GridObject>();
        
        if (go is BaseMissile)
        {
            gameMan.getUIHandler().collectPart();
            gameMan.getLevelManager().collectPart();
            Destroy(gameObject);
        }else if(go is ParticleExplosion)
        {
            destroyed = true;
            Destroy(gameObject);
        }
       
        base.OnTriggerEnter2D(collision);
    }
}
