using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public Vector3 target = new Vector3();
    float killTimer = 0.0f;
    float killDelay = 5.0f;
    float speed = 1.5f;
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
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            coll.gameObject.SendMessage("TakeDamage");
            GameObject.Destroy(gameObject);
        }
    }
}
