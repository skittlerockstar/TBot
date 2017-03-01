using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUFireMissile : PowerUp {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameMan.getPlayer().activeWeapons.Add(AssHandler.Weapons.FireMissile);
        base.OnTriggerEnter2D(collision);
    }
}
