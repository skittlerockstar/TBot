using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;
using System;

public class LevelBuilder : MonoBehaviour {
    public static bool isDone = false;
    public static List<BlockPortal> portalList = new List<BlockPortal>();
	// Use this for initialization
	void Awake () {
        JSONNode json = LoadJson(1,1);
        loadPowerUps(json["powerUps"].AsArray);
        loadLevel(json["blocks"].AsArray);
        JSONNode portalInfo = json["blockInfo"]["portalConnections"];
        loadPortals(portalInfo.AsArray);
	}

    private void loadPowerUps(JSONArray asArray)
    {
       
    }

    private static void loadPortals(JSONArray asArray)
    {
        int index = 0;
        foreach (BlockPortal bp in portalList)
        {
            bp.connected = portalList[asArray[index].AsInt];
            index++;
        }
    }

    //TODO cleanup
    private void loadLevel(JSONArray asArray)
    {
        int cols = GridHandler.columns;
        GameObject g2 = AssHandler.Instantiate(AssHandler.Player.TBot);
        g2.GetComponent<GridObject>().Initialize(Vector2.zero,Vector2.zero);
        int y = 2;
        int x = 1;
        for (int i = 1; i < asArray.Count+1; i++)
        {   if (asArray[i - 1].AsInt != -1)
            {
                AssHandler.Blocks gg = (AssHandler.Blocks)Enum.ToObject(typeof(AssHandler.Blocks), asArray[i - 1].AsInt);
                GameObject g;
                g = AssHandler.Instantiate(gg);
                GridObject gridobj = g.GetComponent<GridObject>();
                gridobj.Initialize(new Vector2(x, y), new Vector2(1, 1));
                
                
                if (gridobj.GetType() == typeof(BlockPortal))
                {
                    BlockPortal bp = (BlockPortal)gridobj;
                    portalList.Add(bp);
                }
            }
            x++;
            if (x == 14)
            {
                x = 1;
                y++;
            }
        }
        isDone = true;
    }

    public JSONNode LoadJson(int world,int level)
    { 
        string text = AssHandler.getLevelFile(world,level);
        JSONNode s = JSON.Parse(text);
        return s;
    }

}
