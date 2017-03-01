using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;

public class TBot : GridObject {
    private Vector2 startPosition = new Vector2(7,14);
    private Vector2 startSize = new Vector2(2, 2);
    public AssHandler.Weapons currentWeapon = AssHandler.Weapons.NormalMissile;
    public List<AssHandler.Weapons> activeWeapons = new List<AssHandler.Weapons>();
    private Vector2 oldPos;
    private bool isOverUI = false;
    public override void Initialize(Vector2 position, Vector2 size)
    {
        
    }

    // Use this for initialization
    void Start () {
        activeWeapons.Add(AssHandler.Weapons.NormalMissile);
        setParams(startPosition, startSize);
        gridHand.resetHitBox(gameObject,new Vector2(0.5f,0.5f));
        gridPos -= new Vector2(0.5f, 0);
       
    }
    // Update is called once per frame
    public float timendstuff = 0;
	void Update () {
        //debugInput();
        androidInput();
    }

    private void androidInput()
    {

        if (oldPos == new Vector2(0.0f,0.0f)) oldPos = gridPos;
        int tCount = Input.touchCount;
        if (tCount > 0)
        {
            
            Touch t = Input.GetTouch(0);
            if (EventSystem.current.IsPointerOverGameObject(t.fingerId)) isOverUI = true;

            Ray2D ray = new Ray2D(Input.mousePosition, Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(t.position.x, t.position.y - 3, 0)), Vector2.zero);
            
            if (hit.transform != null && (hit.transform.gameObject.GetComponent<GridObject>() is IClickable))
            {
                Debug.Log(hit.transform.name);
                if ( t.phase == TouchPhase.Began)
                {
                    GameObject g = hit.transform.gameObject;
                    GridObject gg = g.GetComponent<GridObject>();
                    gg.OnRayEnter();
                }
            }
            else if(!isOverUI)
            {
                
                Vector2 pos = gridHand.touchToGrid(t.position);
                gridPos = new Vector2(pos.x, gridPos.y);
                if (t.phase == TouchPhase.Ended && (System.Math.Round(oldPos.x,1) == System.Math.Round(gridPos.x, 1)))
                {
                    fireMissile();
                }
                if (t.phase == TouchPhase.Ended)
                {
                    oldPos = gridPos;
                }
            }
            if (t.phase == TouchPhase.Ended) isOverUI = false;
        }
        
    }

    private void debugInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            int tCount = Input.touchCount;
            //Touch t = Input.GetTouch(0);
            Ray2D ray = new Ray2D(Input.mousePosition, Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y - 3, 0)), Vector2.zero);


            if (hit.transform != null)
            {
                GameObject g = hit.transform.gameObject;
                GridObject gg = g.GetComponent<GridObject>();
                Debug.Log(gg);
                gg.OnRayEnter();
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridPos += new Vector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridPos += new Vector2(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fireMissile();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
           
            currentWeapon = AssHandler.Weapons.NormalMissile;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (activeWeapons.Contains(AssHandler.Weapons.FireMissile)) {
                currentWeapon = AssHandler.Weapons.FireMissile;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (activeWeapons.Contains(AssHandler.Weapons.IceMissile)) {
                currentWeapon = AssHandler.Weapons.IceMissile;
            }
        }
    }
    public void setWeapon(AssHandler.Weapons weapon)
    {
        if (activeWeapons.Contains(weapon))
        {
            currentWeapon = weapon;
        }
    }
    private void fireMissile()
    {
        GameObject g;
        g = AssHandler.Instantiate(currentWeapon);
        g.GetComponent<BaseMissile>().Initialize(gridPos+new Vector2(0.5f,0), new Vector2(1, 1));
        g.transform.parent = GameManager.getGameManager().getLevelHolder().transform;
    }
    void FixedUpdate()
    {
        gridHand.placeObjectAt(gameObject, gridPos, size);
    }

    public override void setType()
    {
        type = AssHandler.Player.TBot;
    }
}
