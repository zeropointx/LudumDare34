using UnityEngine;
using System.Collections;

public class EnemyHandler : MonoBehaviour {
    GenerateTileMap tilemapScript;
    public GameObject enemy;
    float spawnTimer = 0.0f;
    float spawnDelay = 5.0f;
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
        GameObject.Instantiate(enemy, tilemapScript.enemySpawn.transform.position, new Quaternion());
    }
}
