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
        if (other.gameObject.tag == "Tree")
        {
            other.gameObject.GetComponent<TreeBehaviour>().Damage(4);
            Destroy(this.gameObject);
        }
    }

    void OnMouseDown() {
        Destroy(this.gameObject);
    }
}
