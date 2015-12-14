using UnityEngine;
using System.Collections;

public class appleScript : MonoBehaviour {

    float timer = 0;
    public float witherTimer = 8;
    // Use this for initialization
	void Start () 
    {

	
	}
	
	// Update is called once per frame
	void Update () 
    {
        timer += Time.deltaTime;
        if (timer >= witherTimer)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D coll)
    {       
        if(coll.gameObject.tag == "grapper")
        {
            Destroy(gameObject);
            GlobalVariables.globalVariables.addMoney(10);
        }
    }
}
