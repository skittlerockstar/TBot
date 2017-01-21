using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TBot : GridObject {
    private Vector2 startPosition = new Vector2(7,18);
    private Vector2 startSize = new Vector2(1, 2);
    private AssHandler.Weapons currentWeapon = AssHandler.Weapons.NormalMissile;
    public override void Initialize(Vector2 position, Vector2 size)
    {
        
    }

    // Use this for initialization
    void Start () {
        setParams(startPosition, startSize);
    }
	
	// Update is called once per frame
	void Update () {
        debugInput();
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 touchDeltaPosition = Input.GetTouch(0).position;
            Vector2 pos = GridHandler.touchToGrid(touchDeltaPosition);
            gameObject.transform.localPosition = new Vector3(pos.x,gameObject.transform.localPosition.y);
        }
    }

    private void debugInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gridPos += new Vector2(-1, 0);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            gridPos += new Vector2(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            gridPos += new Vector2(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            gridPos += new Vector2(0, 1);
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
            currentWeapon = AssHandler.Weapons.FireMissile;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentWeapon = AssHandler.Weapons.IceMissile;
        }
    }
    private void fireMissile()
    {
        
        GameObject g;
        g = AssHandler.Instantiate(currentWeapon);
        g.GetComponent<BaseMissile>().Initialize(gridPos, new Vector2(1, 1));
    }
    void FixedUpdate()
    {
        GridHandler.placeObjectAt(gameObject, gridPos, size);
    }

    public override void setType()
    {
        type = AssHandler.Player.TBot;
    }
}
