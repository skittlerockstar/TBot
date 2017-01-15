using UnityEngine;
using System.Collections;
using System;

public class BlockCrate : BaseCrate
{
    public override void setType()
    {
        type = AssHandler.Blocks.Crate;
    }
}
