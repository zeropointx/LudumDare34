using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyHandler : MonoBehaviour {
    List<GameObject> enemies = new List<GameObject>();
    GenerateTileMap tilemapScript;
    public GameObject enemy;
    float spawnTimer = 0.0f;
    float spawnDelay = 1.0f;
	// Use this for initialization
	void Start () {
        tilemapScript = GameObject.Find("Map").GetComponent<GenerateTileMap>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if(spawnTimer >= spawnDelay)
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

        enemies.Add((GameObject)GameObject.Instantiate(enemy, tilemapScript.enemySpawn.transform.position, Enemy.GetRotation(tempPos)));
    }
}
