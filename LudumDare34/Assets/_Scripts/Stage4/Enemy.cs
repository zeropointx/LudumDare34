using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    GenerateTileMap tilemapScript;
    GameObject currentTarget = null;
	// Use this for initialization
	void Start () {
        tilemapScript = GameObject.Find("Map").GetComponent<GenerateTileMap>();
	}
	
	// Update is called once per frame
	void Update () {
        if (currentTarget == null)
            currentTarget = tilemapScript.enemySpawn;
        else
        {
            //if(Vector2.Distance( new Vector2()))
        }
	}
}
