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
        if (spawnTimer >= 4) {
            spawnTimer = 0;
            GameObject clone = Instantiate(enemy);
            Vector3 pos = new Vector3(0.25f, 1.0f + 0.1f * Random.Range(0, 16), 0);
            float dir = 1;
            if (Random.value > 0.5)
            {
                pos.x = 17.5f;
                dir *= -1;
                clone.GetComponent<SpriteRenderer>().flipX = true;
            }
            clone.transform.position = pos;
            clone.GetComponent<EnemyRabbitBehaviour>().direction = dir;
            clone.GetComponent<EnemyRabbitBehaviour>().speed = Random.Range(0.2f, 0.85f);
            clone.transform.parent = transform.parent;
        }
	}
}
