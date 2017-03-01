using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    private LevelManager levelManager;  public LevelManager getLevelManager()   { return levelManager; }
    private LevelBuilder levelBuilder;  public LevelBuilder getLevelBuilder()   { return levelBuilder; }
    private GridHandler gridHandler;    public GridHandler  getGridHandler()    { return gridHandler; }
    private TBot player;                public void setPlayer(TBot player)  { this.player = player; }
                                        public TBot getPlayer() { return player; }
    private GameObject levelHolder;     public GameObject getLevelHolder() { return levelHolder; }
    private UIHandler uiHandler;        public UIHandler getUIHandler() { return uiHandler; }
    public void Awake()
    {
        instance = this;
        uiHandler = GameObject.Find("Canvas").GetComponent<UIHandler>();
        uiHandler.init();
        levelManager = gameObject.GetComponent<LevelManager>();
        levelManager.init();
        levelBuilder = gameObject.GetComponent<LevelBuilder>();
        gridHandler = gameObject.GetComponent<GridHandler>();
        levelHolder = GameObject.Find("LevelHolder");
        levelBuilder.init();
    }
    public static GameManager getGameManager()
    {
        return instance;
    }
    public static GameObject findChild(GameObject parent,string nameOfChild)
    {
        foreach(Transform t in parent.transform)
        {
            if (t.name.Equals(nameOfChild)) return t.gameObject;
        }
        return null;
    }
    private void Update()
    {
        handleHardwareButtons();
    }
    private void handleHardwareButtons()
    {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                LevelManager.gamestate = LevelManager.GameState.Paused;
            }
        
    }
}
