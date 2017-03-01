using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockPortal : BaseCrate
{
    public static List<BlockPortal> portals = new List<BlockPortal>();
    public List<GameObject> dontTransport = new List<GameObject>();
    public int connectedIndex;
    public override void setType()
    {
        type = AssHandler.Blocks.Portal;
    }

    // Use this for initialization
    void Start () {
       setCollisionBehaviour(new ICNothing(null),true);
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision) { 
        GameObject collider = collision.gameObject;
        if (!dontTransport.Contains(collider)){
            BlockPortal.portals[connectedIndex].receiveTransportation(collider);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        dontTransport.Remove(collision.gameObject);
    }
    public void receiveTransportation(GameObject gameObject)
    {
        dontTransport.Add(gameObject);
        gameObject.transform.localPosition = this.transform.localPosition;
    }
}
