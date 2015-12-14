using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EnemyHandler : MonoBehaviour {
    public List<GameObject> enemies = new List<GameObject>();
    GenerateTileMap tilemapScript;
    public GameObject[] enemy;
    float spawnTimer = 0.0f;
    float currentSpawnDelay = 0.0f;
    float spawnDelayMax = 10.0f;
    float spawnDelayMin = 1.0f;
    float spawnDelayDecrementMultiplier = 0.03f;
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


            if (spawnTimer >= currentSpawnDelay)
            {
                spawnTimer = 0.0f;
                currentSpawnDelay = Random.Range(spawnDelayMin, spawnDelayMax);
                SpawnEnemy();
                spawnDelayMax -= spawnDelayMax *spawnDelayDecrementMultiplier;
                if (spawnDelayMax < spawnDelayMin)
                    spawnDelayMax = spawnDelayMin;
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
