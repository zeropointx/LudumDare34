using UnityEngine;
using System.Collections;


public class spawnerScript : MonoBehaviour
{
    float spawnTimer = 0;
    public GameObject apple;
    public int RandomSeed = 50;
    public float spawnInterval = 5;

    grapperScript GrapperScript;
    // Use this for initialization
    void Start()
    {
        GameObject Grapper = GameObject.Find("grapper");
        GrapperScript = Grapper.GetComponent<grapperScript>();
        Random.seed = RandomSeed;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0;
            //kovakoodattu koska fuk
            Vector3 position = new Vector3(Random.Range(-17.0f, -0.81f), Random.Range(-6.7f,-0.62f), 0);
            new WaitForSeconds(spawnTimer);
            Instantiate(apple, position, Quaternion.identity);
        }
    }
}
