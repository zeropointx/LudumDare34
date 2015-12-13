using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public float timeBetween = 10;
    public float timeElapsed = 0;
    public int sceneSelect = 2;
	// Use this for initialization
	void Start () 
    {
        transform.GetComponent<ChangeStage>().ChangeScene(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        GlobalVariables.globalVariables.setTime(timeBetween-timeElapsed);
        if(sceneSelect >= 0)
        { 
            timeElapsed += Time.deltaTime;
            
            if (timeElapsed >= timeBetween)
            {
                transform.GetComponent<ChangeStage>().ChangeScene(sceneSelect);
                ++sceneSelect;
                timeElapsed = 0;
            }
        }

	}
}
