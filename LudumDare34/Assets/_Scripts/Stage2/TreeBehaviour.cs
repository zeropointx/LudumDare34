using UnityEngine;
using System.Collections;

public class TreeBehaviour : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	     
	}

    public void Damage(int damage) {
        GlobalVariables.globalVariables.reduceHp(damage);
    }
}
