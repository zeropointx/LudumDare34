using UnityEngine;
using System.Collections;

public class witheringScript : MonoBehaviour
{
    public SpriteRenderer sprout;
    public float withering;
    public float withering2;
    float timeElapsed = 0;
	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        withering = GameObject.Find("Water Bar").GetComponent<WaterScript>().waterAmount;
        withering2 = GameObject.Find("Nutrient Bar").GetComponent<NutrientScript>().waterAmount;//kiitos miika
        var color = sprout.color;
        color.a = (withering + withering2 / 200);
        sprout.color = color;

        if (withering <= 0 || withering2 <= 0)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 1)
            {
                timeElapsed = 0;
                GlobalVariables.globalVariables.addHp(-4);
            }
            
        }
    }
}
