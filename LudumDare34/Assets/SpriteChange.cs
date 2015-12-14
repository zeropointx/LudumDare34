using UnityEngine;
using System.Collections;

public class SpriteChange : MonoBehaviour {
    SceneSwitch sceneSwitch;
    public GameObject tree;
    public GameObject sprout;
    int stageNum;
    public Sprite sprite;
	// Use this for initialization
	void Start ()
    {
        sceneSwitch = GameObject.Find("SceneChange").transform.GetComponent<SceneSwitch>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        stageNum = sceneSwitch.sceneSelect;
        if (stageNum == 1)
        {
            tree.SetActive(true);
            sprout.SetActive(false);
        }
	}
}
