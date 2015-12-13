using UnityEngine;
using System.Collections;

public class button : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnMouseDown()
    {
        transform.parent.GetComponent<WaterScript>().AddWater();
        transform.GetComponent<AudioSource>().Play();
    }
}
