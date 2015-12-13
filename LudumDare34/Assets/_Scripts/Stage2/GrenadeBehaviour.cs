﻿using UnityEngine;
using System.Collections;

public class GrenadeBehaviour : MonoBehaviour {

    private float timer;
    private bool exploded;

	// Use this for initialization
	void Start () {
        timer = 0;
        exploded = false;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (exploded)
        {
            if (timer >= 0.25f)
            {
                Destroy(this.gameObject);
            }
        }
        // fuse
        else if (timer >= 2)
            Explode();
	}

    public void Explode(){
        if (!exploded){
            exploded = true;
            this.gameObject.GetComponent<CircleCollider2D>().radius = 0.2f;
            this.gameObject.GetComponent<Animator>().enabled = true;
            timer = 0;
        }
    }
}
