using UnityEngine;
using System.Collections;

public class TreeBehaviour : MonoBehaviour {

    private int health;

	// Use this for initialization
	void Start () {
        health = 100;
	}
	
	// Update is called once per frame
	void Update () {
	     
	}

    public void Damage(int damage) {
        health -= damage;
        health = Mathf.Max(health, 0);
        Vector3 temp = this.gameObject.transform.FindChild("HealthBar").transform.localScale;
        temp.x = 0.5f * (health / 100.0f );
        this.gameObject.transform.FindChild("HealthBar").transform.localScale = temp;
    }

    public int GetHealth() {
        return health;
    }
}
