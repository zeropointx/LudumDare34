using UnityEngine;
using System.Collections;

public class ChangeStage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeScene(int number)
    {
        Application.LoadLevel("Stage" + number);
    }
}
