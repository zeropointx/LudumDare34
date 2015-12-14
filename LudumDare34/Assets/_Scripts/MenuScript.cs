using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void loadGame()
    {
        SceneManager.LoadScene("scene");
    }

    public void loadMenu()
    {
        SceneManager.LoadScene("menu");
    }

}
