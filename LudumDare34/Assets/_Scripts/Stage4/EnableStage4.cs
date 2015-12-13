using UnityEngine;
using System.Collections;

public class EnableStage4 : MonoBehaviour {
    public GameObject enemyHandlerPrefab;
    public GameObject mapPrefab;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void Enable()
    {
        GameObject map = GameObject.Instantiate(mapPrefab);
        map.name = "Map";
        GameObject enemy = GameObject.Instantiate(enemyHandlerPrefab);
        enemy.name = "EnemyHandler";

    }
}
