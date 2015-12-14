using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour 
{
    public GUIStyle progress_empty;
    public GUIStyle progress_full;

    public float waterAmount;
    //current progress
    public float barDisplay;

    Vector2 position;// = new Vector2(100, 500);
    Vector2 size = new Vector2(100, 50);

    public Texture2D emptyTex;
    public Texture2D fullTex;

    void OnGUI()
    {
        //Vector3 pos = GameObject.Find("Watering button").transform.position;
        Vector3 pos = new Vector3(Screen.width / 4, Screen.height / 2);
        position = pos;// Camera.main.WorldToScreenPoint(pos);
        position.y -= Screen.height* 0.05f;
       // position.y -= 150.0f;
        //draw the background:
        GUI.BeginGroup(new Rect(position.x, position.y, size.x, size.y), emptyTex, progress_empty);

        GUI.Box(new Rect(position.x, position.y, size.x, size.y), fullTex, progress_full);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex, progress_full);

        GUI.EndGroup(); 
        GUI.EndGroup();
    }

    public void AddWater()
    {
        waterAmount += 25.0f;
        if (waterAmount > 100)
            waterAmount = 100;
    }

    void Update()
    {
        waterAmount -= 0.1f;
        if (waterAmount < 0)
            waterAmount = 0;
        //the player's health
        barDisplay = waterAmount / 100;
    }
}
