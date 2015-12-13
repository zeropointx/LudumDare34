using UnityEngine;
using System.Collections;

public class ChangeStage : MonoBehaviour {
    public GameObject stage1;
    public GameObject stage2;
    public GameObject stage3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeScene(int number)
    {
    
        //Application.LoadLevel("Stage" + number);
        switch(number)
        {
            case 1:
                {
                    GameObject.Instantiate(stage1);
                    break;
                }
            case 2:
                {
                    GameObject.Instantiate(stage2);
                    break;
                }
            case 3:
                {
                    GameObject.Instantiate(stage3);
                    break;
                }
            case 4:
                {
                    transform.GetComponent<EnableStage4>().Enable();
                    break;
                }
        }
    }
}
