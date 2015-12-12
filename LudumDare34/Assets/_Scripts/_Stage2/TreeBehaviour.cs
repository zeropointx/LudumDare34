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
        //Debug.Log("health: " + health.ToString());
        Vector3 temp = this.gameObject.transform.FindChild("HealthBar").transform.localScale;
        temp.x = (1.0f / (100.0f / health));
        this.gameObject.transform.FindChild("HealthBar").transform.localScale = temp;
    }

    public int GetHealth() {
        return health;
    }
}
