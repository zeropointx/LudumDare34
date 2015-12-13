using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 target = new Vector3();
    float killTimer = 0.0f;
    float killDelay = 1.0f;
    float speed = 2.5f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        killTimer += Time.deltaTime;
        if(killTimer >= killDelay)
        {
            GameObject.Destroy(gameObject);
        }
        GetComponent<Rigidbody2D>().velocity = (target.normalized * speed);
	}
}
