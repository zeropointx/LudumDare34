using UnityEngine;
using System.Collections;

public class EnemyRabbitBehaviour : MonoBehaviour {

    public float direction;
    public float speed;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(1, 0, 0) * speed * direction * Time.deltaTime;
	}

    void OnTriggerEnter2D(Collider2D other) {
        string name = other.gameObject.name;
        if (other.gameObject.tag == "Tree")
        {
            other.gameObject.GetComponent<TreeBehaviour>().Damage(4);
            Destroy(this.gameObject);
        }
        else if (name == "Grenade")
        {
            other.gameObject.GetComponent<GrenadeBehaviour>().Explode();
            Destroy(this.gameObject);
        }
    }
}
