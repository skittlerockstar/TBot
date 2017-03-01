using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

    private static Manager manager; public static Manager getManager() { return manager; }
    private int currentLevel = 0; public int getLevel() { return currentLevel; }
    public void setLevel(int i)
    {
        currentLevel = i;
    }
	// Use this for initialization
	void Awake () {
        manager = this;
        DontDestroyOnLoad(gameObject);
	}
	
}
