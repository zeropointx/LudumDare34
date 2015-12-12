using UnityEngine;
using System.Collections;

public class rotateButtonScript : MonoBehaviour {

    grapperScript GrapperScript;
	// Use this for initialization
	void Start () 
    {
        GameObject Grapper = GameObject.Find("grapper");
        GrapperScript = Grapper.GetComponent<grapperScript>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        if(GrapperScript.horizontalMode)
        {
            GrapperScript.horizontalMode = false;
            GrapperScript.verticalMode = true;
        }
        
        else if(GrapperScript.verticalMode)
        {
            GrapperScript.horizontalMode = true;
            GrapperScript.verticalMode = false;
        }
    }
}
