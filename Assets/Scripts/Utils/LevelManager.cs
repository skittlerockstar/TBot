using System;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    private GameManager gameMan;
    private int timeMin = 0;
    private int timeSec = 0;
    private float totalTime;
    private int partsToCollect = 0, partsCollected = 0;
    private UIHandler uiHandler;
    private float passedTime = 0;
    private float fluentTimer = 0;
    public WinCriteria winCriteria = new WinCriteria(null);

    

    public LoseCriteria loseCriteria = new LoseCriteria(null);

    public enum GameState { Active, Paused, Lost, Won, WeaponSelect};
    public static GameState gamestate = GameState.Paused;
    
    public void init()
    { 
        gameMan = GameManager.getGameManager();
        uiHandler = gameMan.getUIHandler();
    }
    public void startGame()
    {
        partsCollected = 0;
        partsToCollect = 0;
        fluentTimer = 0;
        uiHandler.reset();
        gameMan.getLevelHolder().transform.localPosition = new Vector3(0, -0.25f, 0);
        winCriteria = new WinCriteria(() =>(partsCollected == partsToCollect && partsToCollect != 0));
        loseCriteria = new LoseCriteria(() =>(timeMin == 0 && timeSec == 0));
    }

    public void collectPart()
    {
        partsCollected++;
    }
    public void addPart()
    {
        partsToCollect++;
    }

    private void Update()
    {
        switch (gamestate)
        {
            case GameState.Active:
                timer();
                Time.timeScale = 1.0f;
                break;
            case GameState.Paused:
                Time.timeScale = 0.0f;
                break;
            case GameState.Lost:
                Time.timeScale = 0.0f;
                break;
            case GameState.Won:
                Time.timeScale = 0.0f;
                break;
            case GameState.WeaponSelect:
                Time.timeScale = 0.0f;
                break;
        }
        handleGameState();
    }

    private void handleGameState()
    {
        if (winCriteria.criteriaMet()) gamestate = GameState.Won;
        else if (loseCriteria.criteriaMet()) gamestate = GameState.Lost;
    }

    private void timer()
    {
        if (timeSec <= 0) { timeSec = 60; timeMin--; }
        timeSec = (passedTime >= 1.0f ? timeSec - 1 : timeSec);
        passedTime = (passedTime >= 1.0f ? 0 : passedTime + Time.deltaTime);
        
        String min = timeMin.ToString("00"), sec = timeSec.ToString("00");
        uiHandler.setTimeText(min + ":" + sec);
        float total = 800;
        fluentTimer += Time.deltaTime;
        total = 800 * ((totalTime - fluentTimer) / totalTime);
        uiHandler.updateTimeBar(800-total, (totalTime - fluentTimer) / totalTime);
    }

    public void setTime(int min, int sec)
    {
        timeMin = min;
        timeSec = sec;
        totalTime = (min * 60) + sec;
    }
    
}
