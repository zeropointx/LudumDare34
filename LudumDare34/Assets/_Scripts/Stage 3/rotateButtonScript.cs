using UnityEngine;
using System.Collections;

public class rotateButtonScript : MonoBehaviour {

    grapperScript GrapperScript;
    public Sprite JoyRight, JoyLeft, JoyUp, JoyDown;

	// Use this for initialization
	void Start () 
    {
        GameObject Grapper = GameObject.Find("grapper");
        GrapperScript = Grapper.GetComponent<grapperScript>();
	}
	
	// Update is called once per frame

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

    void Update()
    {
        updateSprite();
    }

    void updateSprite()
    {
        if (GrapperScript.verticalMode)
        {
            if (GrapperScript.vPlus)
                GetComponent<SpriteRenderer>().sprite = JoyUp;

            if (GrapperScript.vMinus)
                GetComponent<SpriteRenderer>().sprite = JoyDown;

        }

        else
        {
            if (GrapperScript.hMinus)
                GetComponent<SpriteRenderer>().sprite = JoyLeft;

            if (GrapperScript.hPlus)
                GetComponent<SpriteRenderer>().sprite = JoyRight;
        }
    }
}
