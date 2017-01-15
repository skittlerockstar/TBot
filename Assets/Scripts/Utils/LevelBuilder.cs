using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;
using System;

public class LevelBuilder : MonoBehaviour {
    public static bool isDone = false;
	// Use this for initialization
	void Awake () {
        JSONNode json = LoadJson(1,1);
        loadLevel(json["blocks"].AsArray);
	}
    //TODO cleanup
    private void loadLevel(JSONArray asArray)
    {
        int cols = GridHandler.columns;
        GameObject g2 = AssHandler.Instantiate(AssHandler.GameObjects.TBOT);
        int y = 2;
        int x = 1;
        for (int i = 1; i < asArray.Count+1; i++)
        {
            AssHandler.Blocks gg = (AssHandler.Blocks)Enum.ToObject(typeof(AssHandler.Blocks), asArray[i-1].AsInt);
            GameObject g;
                g = AssHandler.Instantiate(gg);            
                g.GetComponent<GridObject>().Initialize(new Vector2(x, y), new Vector2(1, 1));
            x++;
            if(x == 14)
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
