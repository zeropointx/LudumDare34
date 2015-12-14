using UnityEngine;
using System.Collections;

public class EnemyRabbitBehaviour : MonoBehaviour {

    public float direction;
    public float speed;
    public GameObject bloodEffect;

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
        else if (other.gameObject.name == "Grenade")
        {
            other.gameObject.GetComponent<GrenadeBehaviour>().Explode();
            SpawnBlood();
            Destroy(this.gameObject);
        }
    }

    private void SpawnBlood() {
        GameObject blood = Instantiate(bloodEffect);
        blood.transform.position = transform.position;
    }
}
