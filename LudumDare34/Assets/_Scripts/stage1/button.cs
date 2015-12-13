using UnityEngine;
using System.Collections;

public class button : MonoBehaviour {
    public AudioSource source;
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        transform.parent.GetComponent<WaterScript>().AddWater();
        AudioSource a = transform.GetComponent<AudioSource>();
        transform.GetComponent<AudioSource>().Play();
        source.Play();
    }
}
