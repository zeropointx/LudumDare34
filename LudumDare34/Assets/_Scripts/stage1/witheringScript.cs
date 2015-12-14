﻿using UnityEngine;
using System.Collections;

public class witheringScript : MonoBehaviour
{
    public SpriteRenderer sprout;
    public float withering;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        withering = transform.FindChild("Water Bar").GetComponent<WaterScript>().waterAmount;
        withering += transform.FindChild("Nutrient Bar").GetComponent<NutrientScript>().waterAmount;//kiitos miika
        var color = sprout.color;
        color.a = (withering / 200);
        sprout.color = color;

        if (withering <= 0)
        {
            GlobalVariables.globalVariables.addHp(-1);
        }
    }
}
