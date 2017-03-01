using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using System;
using System.IO;
using UnityEngine.UI;

public class AssHandler :MonoBehaviour{
    private const string ASSET_ROOT = "Assets/",RESOURCE_ROOT = ASSET_ROOT+"Resources/";
    private const string PREFAB_ROOT = "Prefabs/",
                        SPRITE_ROOT = "Sprites/",
                        DECORATOR_ROOT = PREFAB_ROOT+"Decorators/",
                        BLOCKS_ROOT = PREFAB_ROOT + "Blocks/",
                        POWERUPS_ROOT = PREFAB_ROOT + "PowerUps/",
                        MISSILE_ROOT = PREFAB_ROOT + "Missiles/",
                        UI_ROOT = PREFAB_ROOT + "UI/",
                        LEVEL_DATA_ROOT = "LevelData/Levels/",
                        WORLD_DATA_ROOT = "LevelData/Worlds/";
    public enum Sprites { }
    public enum Player { TBot }
    public enum Decorators { Explosion }
    public enum Weapons { NormalMissile,FireMissile,IceMissile}
    public enum Blocks { Granite,Crate,MetalCrate,Bomb, Arrow, Part,Portal};
    public enum PowerUps { IceMissile,FireMissile };
    private static Dictionary<Player, Object> player = new Dictionary<Player, Object>()
    {
        {Player.TBot,Resources.Load(PREFAB_ROOT+"Player")}
    };
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
    private static Dictionary<Blocks, Object> blocks = new Dictionary<Blocks, Object>()
    {
        {Blocks.Granite,Resources.Load(BLOCKS_ROOT+"granite")},
        {Blocks.Crate,Resources.Load(BLOCKS_ROOT+"crate")},
        {Blocks.MetalCrate,Resources.Load(BLOCKS_ROOT+"metalCrate")},
        {Blocks.Bomb,Resources.Load(BLOCKS_ROOT+"bomb")},
        {Blocks.Arrow,Resources.Load(BLOCKS_ROOT+"arrow")},
        {Blocks.Part,Resources.Load(BLOCKS_ROOT+"part")},
          {Blocks.Portal,Resources.Load(BLOCKS_ROOT+"portal")}
    };
    private static Dictionary<PowerUps, Object> powerups = new Dictionary<PowerUps, Object>()
    {
         {PowerUps.IceMissile,Resources.Load(POWERUPS_ROOT+"IceMissile")},
        {PowerUps.FireMissile,Resources.Load(POWERUPS_ROOT+"FireMissile")}
    };
    public static GameObject Instantiate(Player p) 
    {
    return Instantiate(player[p]) as GameObject;
    }
    public static GameObject Instantiate(Blocks b)
    {   
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
    public static GameObject Instantiate(PowerUps b)
    {
        return Instantiate(powerups[b]) as GameObject;
    }

    public static string getLevelFile(int world, int level)
    {
        Debug.Log(level);
        TextAsset ass = Resources.Load(LEVEL_DATA_ROOT + world + "-" + level) as TextAsset;
        return ass.ToString();
    }
    public static string getWorldFile(int world)
    {
        TextAsset ass = Resources.Load(WORLD_DATA_ROOT + world) as TextAsset;
        return ass.ToString();
    }

    public static Button createLevelSelector()
    {
        GameObject b =  Instantiate(Resources.Load(UI_ROOT + "LevelSelector")) as GameObject;
        return b.GetComponent<Button>();
    }
}
