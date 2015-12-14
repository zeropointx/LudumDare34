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
        position = transform.parent.position;
        position.x += 485;
        position.y += 300;
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
        waterAmount -= 0.125f;
        if (waterAmount < 0)
            waterAmount = 0;
        //the player's health
        barDisplay = waterAmount / 100;
    }
}
