using UnityEngine;
using System.Collections;

public class TextboxChanger : MonoBehaviour {

    public GameObject Textbox1;
    public GameObject Textbox2;
    public GameObject Textbox3;
    public GameObject Textbox4;

	// Use this for initialization
    void Awake()
    {
        setBox2(false);
        setBox3(false);
        setBox4(false);
    }

	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {	
	}

    public void setBox1(bool state)
    {
        Textbox1.SetActive(state);
    }

    public void setBox2(bool state)
    {
        Textbox2.SetActive(state);
    }

    public void setBox3(bool state)
    {
        Textbox3.SetActive(state);
    }

    public void setBox4(bool state)
    {
        Textbox4.SetActive(state);
    }
}

