using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIMainMenu : MonoBehaviour {

    public Button start, settings, quit;
	void Start () {
        setHandlers();
	}

    private void setHandlers()
    {
        start.onClick.AddListener(() => { SceneManager.LoadSceneAsync(1); });
        settings.onClick.AddListener(() => { });
        quit.onClick.AddListener(() => { Application.Quit(); });
    }
}
