﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyHandler : MonoBehaviour {
    public List<GameObject> enemies = new List<GameObject>();
    GenerateTileMap tilemapScript;
    public GameObject[] enemy;
    float spawnTimer = 0.0f;
    float spawnDelay = 1.0f;
	// Use this for initialization
	void Start () {
        tilemapScript = GameObject.Find("Map").GetComponent<GenerateTileMap>();
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < enemies.Count; i++ )
        {
            if (enemies[i] == null)
                enemies.Remove(enemies[i]);
        }


            if (spawnTimer >= spawnDelay)
            {
                spawnTimer = 0.0f;
                SpawnEnemy();
            }
        spawnTimer += Time.deltaTime;
	}
    void SpawnEnemy()
    {
        GameObject nextTile = tilemapScript.getNextTilePath(tilemapScript.enemySpawn);
        Vector3 tempPos =  nextTile.transform.position - tilemapScript.enemySpawn.transform.position;
        int randomNumber = Random.Range(0, enemy.Length);
        enemies.Add((GameObject)GameObject.Instantiate(enemy[randomNumber], tilemapScript.enemySpawn.transform.position, Enemy.GetRotation(tempPos)));
    }
}
