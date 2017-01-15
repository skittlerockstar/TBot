﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;
using System.IO;

public class AssHandler :MonoBehaviour{
    private const string ASSET_ROOT = "Assets/",RESOURCE_ROOT = ASSET_ROOT+"Resources/";
    private const string PREFAB_ROOT = "Prefabs/",
                        SPRITE_ROOT = "Sprites/",
                        DECORATOR_ROOT = PREFAB_ROOT+"Decorators/",
                        BLOCKS_ROOT = PREFAB_ROOT + "Blocks/", 
                        MISSILE_ROOT = PREFAB_ROOT + "Missiles/",
                        LEVEL_DATA_ROOT = "LevelData/";
    public enum Sprites { }
    public enum GameObjects {TBOT,TESTBLOCK,TESTBLOCK2,TESTMISSILE}
    public enum Decorators { Explosion }
    public enum Weapons { NormalMissile,FireMissile,IceMissile}
    public enum Blocks { Granite,Crate,MetalCrate,Bomb, Arrow, Part,UpgradeIce,UpgradeFire,Portal};
    private static Dictionary<Decorators, Object> decorators = new Dictionary<Decorators, Object>()
    {
        {Decorators.Explosion,Resources.Load(DECORATOR_ROOT+"explosion")}
    };
    private static Dictionary<Weapons, Object> weapons = new Dictionary<Weapons, Object>()
    {
        {Weapons.NormalMissile,Resources.Load(MISSILE_ROOT+"normalMissile")},
        {Weapons.FireMissile,Resources.Load(MISSILE_ROOT+"fireMissile")},
        {Weapons.IceMissile,Resources.Load(MISSILE_ROOT+"iceMissile") }
    };
    private static Dictionary<GameObjects, Object> gObjects = new Dictionary<GameObjects, Object>()
    {
        {GameObjects.TBOT,Resources.Load(PREFAB_ROOT+"Player")},
        {GameObjects.TESTBLOCK,Resources.Load(BLOCKS_ROOT+"testblock")},
        {GameObjects.TESTBLOCK2,Resources.Load(BLOCKS_ROOT+"testblock2")},
         {GameObjects.TESTMISSILE,Resources.Load(MISSILE_ROOT+"testMissile")}
    };
    private static Dictionary<Blocks, Object> blocks = new Dictionary<Blocks, Object>()
    {
        {Blocks.Granite,Resources.Load(BLOCKS_ROOT+"granite")},
        {Blocks.Crate,Resources.Load(BLOCKS_ROOT+"crate")},
        {Blocks.MetalCrate,Resources.Load(BLOCKS_ROOT+"metalCrate")},
         {Blocks.Bomb,Resources.Load(BLOCKS_ROOT+"bomb")},
          {Blocks.Arrow,Resources.Load(BLOCKS_ROOT+"bomb")},
           {Blocks.Part,Resources.Load(BLOCKS_ROOT+"part")}
    };

    public static GameObject Instantiate(GameObjects g)
    {
        return Instantiate(gObjects[g]) as GameObject;
    }
    public static GameObject Instantiate(Blocks b)
    {
        Debug.Log(b);
        return Instantiate(blocks[b]) as GameObject;
    }
    public static GameObject Instantiate(Decorators b)
    {
        return Instantiate(decorators[b]) as GameObject;
    }
    public static GameObject Instantiate(Weapons b)
    {
        return Instantiate(weapons[b]) as GameObject;
    }

    public static string getLevelFile(int world, int level)
    {   
        return File.ReadAllText(RESOURCE_ROOT+LEVEL_DATA_ROOT + world + "-" + level + ".json");
    }
}