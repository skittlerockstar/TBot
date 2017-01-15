using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class ICNothing : IColImpl {
    public ICNothing(List<IConvertible> exceptions) : base(exceptions)
    {
    }

    public override void doOnEnter(GameObject source, Collider2D collider)
    {
        
    }

    public override void doOnExit(GameObject source, Collider2D collider)
    {
        
    }

    public override void doOnStay(GameObject source, Collider2D collider)
    {
        
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
