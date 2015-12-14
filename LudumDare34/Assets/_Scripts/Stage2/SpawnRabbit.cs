using UnityEngine;
using System.Collections;

public class SpawnRabbit : MonoBehaviour {

    public GameObject enemy;
    private float spawnTimer;
    private int currentScene;
    private float spawnDelay;
    private float speedMin;
    private float speedMax;

	// Use this for initialization
	void Start () {
	    spawnTimer = 0;
        currentScene = -1;
	}
	
	// Update is called once per frame
	void Update () {
        int scene = GameObject.Find("SceneChange").GetComponent<SceneSwitch>().sceneSelect;
        if (scene > currentScene)
            UpdateDifficulty(scene);

        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnDelay) {
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
            clone.GetComponent<EnemyRabbitBehaviour>().speed = Random.Range(speedMin, speedMax);
            clone.transform.parent = transform.parent;
        }
	}
    private void UpdateDifficulty(int scene){
        currentScene = scene;
        switch(currentScene)
        {
            case 0:
                spawnDelay = 4;
                speedMin = 0.2f;
                speedMax = 0.85f;
                break;

            case 1:
                spawnDelay = 3.5f;
                speedMin = 0.3f;
                speedMax = 0.9f;
                break;

            case 2:
                spawnDelay = 3;
                speedMin = 0.4f;
                speedMax = 0.95f;
                break;

            case 3:
                spawnDelay = 2;
                speedMin = 0.5f;
                speedMax = 1.25f;
                break;

            default:
                break;
        }

    }
}
