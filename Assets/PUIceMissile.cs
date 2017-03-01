using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUIceMissile : PowerUp {
    private void OnTriggerEnter2D(Collider2D other)
    {
        gameMan.getPlayer().activeWeapons.Add(AssHandler.Weapons.IceMissile);
        base.OnTriggerEnter2D(other);
    }
}
