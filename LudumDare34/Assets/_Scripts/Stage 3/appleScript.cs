﻿using UnityEngine;
using System.Collections;

public class appleScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {       
        if(coll.gameObject.tag == "grapper")
        {
            Destroy(gameObject);
            //Anna rahea koodi tähän
        }
    }
}
