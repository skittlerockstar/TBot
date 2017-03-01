using UnityEngine;
using System.Collections;

public class BlockGranite : BaseCrate {

    public override void Initialize(Vector2 position, Vector2 size)
    {
        base.Initialize(position, size);
        setCollisionBehaviour(new ICIndestructable(null));
    }
    public override void setType()
    {
        type = AssHandler.Blocks.Granite;
    }
}
