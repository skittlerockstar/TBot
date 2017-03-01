using UnityEngine;
using System.Collections;
using System;

public class ParticleExplosion : GridObject {
    public override void Initialize(Vector2 position, Vector2 size)
    {
        type = AssHandler.Decorators.Explosion;
       // base.setParams(position, size);'

        base.setCollisionBehaviour(new ICIndestructable(null));
    }

    public override void setType()
    {
        type = AssHandler.Decorators.Explosion;
    }

    // Update is called once per frame
    void Update () {
        if (!gameObject.GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(gameObject);
        }
	}
}
