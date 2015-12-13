using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {
    float delay = 1.0f;
    float timer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if(timer >= delay)
        {
            GameObject.Destroy(gameObject);
        }
	}
}
