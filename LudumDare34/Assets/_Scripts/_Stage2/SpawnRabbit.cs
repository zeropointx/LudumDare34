using UnityEngine;
using System.Collections;

public class SpawnRabbit : MonoBehaviour {

    public GameObject enemy;
    private float spawnTimer;

	// Use this for initialization
	void Start () {
	    spawnTimer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= 2) {
            spawnTimer = 0;
            GameObject clone = Instantiate(enemy);
            Vector3 pos = new Vector3(-11, Random.Range(-2.5f, -3.6f), 0);
            float dir = 1;
            if (Random.value > 0.5)
            {
                pos.x *= -1;
                dir *= -1;
                clone.GetComponent<SpriteRenderer>().flipX = true;
            }
            clone.transform.position = pos;
            clone.GetComponent<EnemyRabbitBehaviour>().direction = dir;
            clone.GetComponent<EnemyRabbitBehaviour>().speed = Random.Range(1, 6);
            clone.transform.parent = transform.parent;
        }
	}
}
