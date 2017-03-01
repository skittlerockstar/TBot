using System.Collections.Generic;
using System.IO;
using UnityEngine;
using SimpleJSON;
using System;

public class LevelBuilder : MonoBehaviour {

    private GameManager gameMan;
    private GridHandler gridHand;
    private GameObject levelHolder;
    private JSONNode levelData,levelInfo, blockInfo;
    private JSONArray blocks, collectables;
    private int currentLevel;
    public void Start()
    {
        
    }
    public void init()
    {
        currentLevel = Manager.getManager().getLevel();
        gameMan = GameManager.getGameManager();
        gridHand = gameMan.getGridHandler();
        levelHolder = gameMan.getLevelHolder();
        loadLevel(1, currentLevel);
    }

    public void loadLevel(int world, int level)
    {
        gameMan.getLevelManager().startGame();
        this.loadJson(world, level);
        this.createLevel(blocks,collectables);
        this.createPlayer();
        this.setLevelInfo(levelInfo);
        
        this.startGame();
    }
    public void startGame()
    {
        LevelManager.gamestate = LevelManager.GameState.Active;
        
    }
    public void resetLevel()
    {
        //TODO remove to cleaner method;
        BlockPortal.portals.Clear();
        
        removeGameObjects();
        loadLevel(1, currentLevel);
    }

    private void removeGameObjects()
    {
        foreach (Transform t in levelHolder.transform)
        {
            Destroy(t.gameObject);
        }
        Destroy(gameMan.getPlayer().gameObject);
    }

    private void setLevelInfo(JSONNode levelInfo)
    {
        int minutes = levelInfo["time"]["minutes"].AsInt;
        int seconds = levelInfo["time"]["seconds"].AsInt;
        gameMan.getLevelManager().setTime(minutes, seconds);
    }

    public void createPlayer()
    {
        GameObject player = AssHandler.Instantiate(AssHandler.Player.TBot);
        player.GetComponent<GridObject>().Initialize(Vector2.zero, Vector2.zero);
        gameMan.setPlayer(player.GetComponent<TBot>());
    }

    public void createLevel(JSONArray blockArray,JSONArray collectables)
    {
        int collectableIndex = 0;
        for (int i = 1; i < blockArray.Count + 1; i++)
        {
            int typeIndex = blockArray[i-1].AsInt;
            if (typeIndex != -1) { createBlock(typeIndex, i); }
            else { createCollectable(collectables[collectableIndex++].AsInt, i); }
        }
    }

    private void createCollectable(int typeIndex,int levelIndex)
    {
        int row = (levelIndex - 1) / (gridHand.columns);
        int col = (levelIndex - 1) % (gridHand.columns);

        AssHandler.PowerUps gg = (AssHandler.PowerUps)Enum.ToObject(typeof(AssHandler.PowerUps), typeIndex);
        GameObject g = AssHandler.Instantiate(gg);
        GridObject gridobj = g.GetComponent<GridObject>();
        g.transform.parent = levelHolder.gameObject.transform;
        gridobj.Initialize(new Vector2(col + 1, row), new Vector2(1, 1));
    }
    private void createBlock(int typeIndex, int levelIndex)
    {
        int row = (levelIndex - 1) / (gridHand.columns);
        int col = (levelIndex-1) % (gridHand.columns);
        
        AssHandler.Blocks gg = (AssHandler.Blocks)Enum.ToObject(typeof(AssHandler.Blocks),typeIndex);
        GameObject g = AssHandler.Instantiate(gg);
        GridObject gridobj = g.GetComponent<GridObject>();
        g.transform.parent = levelHolder.gameObject.transform;
        gridobj.Initialize(new Vector2(col+1, row), new Vector2(1, 1));
        setBlockInfo(gridobj);
    }

    private void setBlockInfo(GridObject gridobj)
    {
        if (gridobj.type.Equals(AssHandler.Blocks.Portal))
        {
            BlockPortal bp = ((BlockPortal)gridobj);
            bp.connectedIndex = blockInfo["portalConnections"][BlockPortal.portals.Count].AsInt;
            BlockPortal.portals.Add(bp);
        }
    }

    public void loadJson(int world,int level)
    { 
        string text = AssHandler.getLevelFile(world,level);
        levelData = JSON.Parse(text);
        blocks = levelData["blocks"].AsArray;
        collectables = levelData["collectables"].AsArray;
        levelInfo = levelData["levelInfo"];
        blockInfo = levelData["blockInfo"];
    }

}
