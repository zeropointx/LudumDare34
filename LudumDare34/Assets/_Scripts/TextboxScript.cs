using UnityEngine;
using System.Collections;

public class TextboxScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
