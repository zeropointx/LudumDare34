using UnityEngine;
using System.Collections;

public class button2 : MonoBehaviour 
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
        transform.parent.GetComponent<NutrientScript>().AddWater();
        transform.GetComponent<AudioSource>().Play();
    }
}
