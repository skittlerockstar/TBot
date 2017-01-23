using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPortal : BaseCrate
{
    public BlockPortal connected;
    public static List<UnityEngine.Object> transportedItems = new List<UnityEngine.Object>();
    public override void setType()
    {
        type = AssHandler.Blocks.Portal;

    }

    // Use this for initialization
    void Start () {
        collisionBehaviour = new ICNothing(null);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transportedItems.Contains(collision.gameObject))
        {
            transportedItems.Remove(collision.gameObject);
        }
        else
        {
            transportedItems.Add(collision.gameObject);
            collision.gameObject.transform.localPosition = connected.gameObject.transform.localPosition;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transportedItems.Add(collision.gameObject);
    }
}
