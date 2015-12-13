using UnityEngine;
using System.Collections;

public class SpriteChange : MonoBehaviour {

    int stageNum;
    public Sprite sprite;
	// Use this for initialization
	void Start ()
    {
        stageNum = GetComponent<SceneSwitch>().sceneSelect;
	}
	
	// Update is called once per frame
	void Update ()
    {
        stageNum = GetComponent<SceneSwitch>().sceneSelect;
        if (stageNum == 2)
        {
            transform.GetComponent<SpriteRenderer>().sprite = sprite;
        }
	}
}
