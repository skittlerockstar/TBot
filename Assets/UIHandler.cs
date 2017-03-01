using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour {

    private GameManager gameMan;
    private GameObject infoBar,screens,gameControlls;
    private GameObject screenGameOver, screenPaused, screenWin;
    private Image toCollect, collected;
    Button normal, fire, ice;
    public Dictionary<AssHandler.Weapons,Button> weaponButtons = new Dictionary<AssHandler.Weapons, Button>();
    public int test = 0;
    public void Awake()
    {
        EventSystem eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        eventSystem.sendNavigationEvents = !eventSystem.sendNavigationEvents;
    }
    public void init()
    {
        gameMan = GameManager.getGameManager();
        screenGameOver = GameObject.Find("GameOver");
        screenPaused = GameObject.Find("Paused");
        screenWin = GameObject.Find("GameWon");
        infoBar = GameObject.Find("InfoBar");
        screens = GameObject.Find("Screens");
        gameControlls = GameObject.Find("GameControllBar");
        toCollect = GameManager.findChild(infoBar, "toCollect").GetComponent<Image>();
        collected = GameManager.findChild(infoBar, "collected").GetComponent<Image>();
        

    }

    public void addPart()
    {
        toCollect.rectTransform.sizeDelta += new Vector2(100, 0);
    }
    public void collectPart()
    {
        collected.rectTransform.sizeDelta += new Vector2(100, 0);
    }

    private void Start()
    {
        setInputHandlers();
    }
    private void Update()
    {
        handleScreenStates();
        handleWeaponAvailability();
    }

    private void handleWeaponAvailability()
    {
        foreach (KeyValuePair<AssHandler.Weapons, Button> weapon in weaponButtons)
        {
            ColorBlock cb = weapon.Value.colors;
            float grayScale = 0.1f;
            
            if (gameMan.getPlayer().activeWeapons.Contains(weapon.Key))
            {
                float opa = 0.5f;
                if (gameMan.getPlayer().currentWeapon == weapon.Key) { weapon.Value.interactable = false; opa = 1f; }
                else { weapon.Value.interactable = true; grayScale = 0.5f; }
                
                cb.normalColor = new Color(cb.disabledColor.r*grayScale, cb.disabledColor.g * grayScale, cb.disabledColor.b * grayScale, opa);
                cb.highlightedColor = new Color(cb.disabledColor.r * grayScale, cb.disabledColor.g * grayScale, cb.disabledColor.b * grayScale, opa+0.3f);
                cb.pressedColor = new Color(cb.pressedColor.r * grayScale, cb.pressedColor.g * grayScale, cb.pressedColor.b * grayScale, opa + 0.3f);
                weapon.Value.colors = cb;
            }else
            {
                cb.normalColor = new Color(0, 0, 0, 0.5f);
                cb.highlightedColor = new Color(0, 0, 0, 0.5f);
                cb.pressedColor = new Color(0, 0, 0, 0.5f);
                weapon.Value.interactable = true;
                weapon.Value.colors = cb;
            }
        }
    }

    public void reset()
    {
        toCollect.rectTransform.sizeDelta = new Vector2(0, 100);
        collected.rectTransform.sizeDelta = new Vector2(0, 100);
    }

    private void handleScreenStates()
    {
        screens.SetActive(LevelManager.gamestate != LevelManager.GameState.Active);
        screenGameOver.SetActive(LevelManager.gamestate == LevelManager.GameState.Lost);
        screenPaused.SetActive(LevelManager.gamestate == LevelManager.GameState.Paused);
        screenWin.SetActive(LevelManager.gamestate == LevelManager.GameState.Won);
    }

    public void setTimeText(String text)
    {
        Text timeText = infoBar.transform.GetChild(0).transform.GetChild(2).GetComponent(typeof(Text)) as Text;
        timeText.text = text;
    }
    public void updateTimeBar(float width,float perc)
    {
        Text rect1 = infoBar.transform.GetChild(0).transform.GetChild(3).GetComponent<Text>();
        rect1.text = ((int)(perc * 100))+"%";
        RectTransform rect  = infoBar.transform.GetChild(0).GetComponent<RectTransform>();
        rect.sizeDelta = new Vector2(width, rect.sizeDelta.y);
    }
    private void setInputHandlers()
    {
        Button gameOverRestart = GameManager.findChild(screenGameOver, "RestartLevel").GetComponent<Button>();
        gameOverRestart.onClick.AddListener(()=> { gameMan.getLevelBuilder().resetLevel(); });
        Button gameOverQuit = GameManager.findChild(screenGameOver, "Quit").GetComponent<Button>();
        gameOverQuit.onClick.AddListener(() => { SceneManager.LoadSceneAsync(1); });

        Button pause = GameObject.Find("Pause").GetComponent<Button>();
        pause.onClick.AddListener(() => { LevelManager.gamestate = LevelManager.GameState.Paused; });

        Button pausedContinue = GameManager.findChild(screenPaused, "Continue").GetComponent<Button>();
        pausedContinue.onClick.AddListener(() => { LevelManager.gamestate = LevelManager.GameState.Active; });
        Button pausedRestart = GameManager.findChild(screenPaused, "RestartLevel").GetComponent<Button>();
        pausedRestart.onClick.AddListener(() => { gameMan.getLevelBuilder().resetLevel(); });
        Button pausedQuit = GameManager.findChild(screenPaused, "Quit").GetComponent<Button>();
        pausedQuit.onClick.AddListener(() => { SceneManager.LoadSceneAsync(1); });
        
     //   Button wonContinue = GameManager.findChild(screenPaused, "Continue").GetComponent<Button>();
     //   wonContinue.onClick.AddListener(() => { LevelManager.gamestate = LevelManager.GameState.Active; });
        Button wonRestart = GameManager.findChild(screenWin, "RestartLevel").GetComponent<Button>();
        wonRestart.onClick.AddListener(() => { gameMan.getLevelBuilder().resetLevel(); });
          Button wonQuit = GameManager.findChild(screenPaused, "Quit").GetComponent<Button>();
          wonQuit.onClick.AddListener(() => { SceneManager.LoadSceneAsync(1); });

        normal = GameObject.Find("Missile Normal").GetComponent<Button>();
        fire = GameObject.Find("Missile Fire").GetComponent<Button>();
        ice = GameObject.Find("Missile Ice").GetComponent<Button>();

        weaponButtons.Add(AssHandler.Weapons.NormalMissile, normal);
        weaponButtons.Add(AssHandler.Weapons.FireMissile, fire);
        weaponButtons.Add(AssHandler.Weapons.IceMissile, ice);
        setWeaponListeners();
    }

    private void setWeaponListeners()
    {
        
        foreach (KeyValuePair<AssHandler.Weapons,Button> weapon in weaponButtons)
        {
            weapon.Value.onClick.RemoveAllListeners();
            weapon.Value.onClick.AddListener(() => { gameMan.getPlayer().setWeapon(weapon.Key); });
        }
    }
}
