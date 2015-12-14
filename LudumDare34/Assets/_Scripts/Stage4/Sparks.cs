using UnityEngine;
using System.Collections;

public class Sparks : MonoBehaviour {
    ParticleSystem system;
	// Use this for initialization
	void Start () {
        system = transform.GetComponent<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
	if(!system.IsAlive())
    {
        GameObject.Destroy(gameObject);
    }
	}
}
