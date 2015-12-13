using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public float timeBetween = 10;
    public float timeElapsed = 0;
    public int sceneSelect = 4;
	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update ()
    { 
        if(sceneSelect >= 0)
        { 
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= timeBetween)
            {
                transform.GetComponent<ChangeStage>().ChangeScene(sceneSelect);
                --sceneSelect;
                timeElapsed = 0;
            }
        }

	}
}
