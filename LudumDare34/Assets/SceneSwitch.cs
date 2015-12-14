﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour {
    float[] timesBetween = new float[]{30.0f,60f,120f,300f};
  //  public float timeBetween = 10;
    public float timeElapsed = 0;
    public int sceneSelect = 0;
	// Use this for initialization
	void Start () 
    {
        transform.GetComponent<ChangeStage>().ChangeScene(1);
	}
	
	// Update is called once per frame
	void Update ()
    {
        GlobalVariables.globalVariables.setTime(timesBetween[sceneSelect]-timeElapsed);
        if(sceneSelect <= 3)
        { 
            timeElapsed += Time.deltaTime;
            
           
            if (timeElapsed >= timesBetween[sceneSelect])
            {
                if (sceneSelect == 3)
                {
                    SceneManager.LoadScene("victoryScene");
                    return;
                }
                ++sceneSelect;
                transform.GetComponent<ChangeStage>().ChangeScene(sceneSelect+1);
               
                timeElapsed = 0;
            }

            
        }
        if(GlobalVariables.globalVariables.hp <= 0)
        {
                SceneManager.LoadScene("gameOver");
        }
	}
}
