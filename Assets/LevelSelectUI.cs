using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectUI : MonoBehaviour {

    // Use this for initialization
   public  GameObject map;
    public Button returnToMain;
	void Start () {
        map = GameObject.Find("Map");
        buildButtons();
        returnToMain.onClick.AddListener(() => SceneManager.LoadSceneAsync(0));
	}

    private void buildButtons()
    {
        JSONNode worldData = JSON.Parse(AssHandler.getWorldFile(1));
        JSONArray buttonLocations = worldData["coordinates"].AsArray;
        for (int i = 0; i < buttonLocations.Count; i++)
        {
            JSONArray b = buttonLocations[i].AsArray;
            int x = b[0].AsInt, y = b[1].AsInt;
            int w = b[2].AsInt, h = b[3].AsInt;
            createButton(x, y, w, h,i);
        }
    }

    private void createButton(int x, int y, int w, int h, int i)
    {
        Button selector = AssHandler.createLevelSelector();
        Debug.Log(selector);
        selector.transform.parent = map.transform;
        RectTransform rtf = selector.GetComponent<RectTransform>();
        rtf.anchoredPosition = new Vector3(x, -y, 0);
        rtf.sizeDelta = new Vector2(w, h);
        selector.onClick.AddListener(() => {
            Manager.getManager().setLevel(i+1);
            SceneManager.LoadSceneAsync(2);
        });
    }

}
