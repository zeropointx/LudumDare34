using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {
    GenerateTileMap generateTileMapScript;
    public int id;
	// Use this for initialization
	void Start () {
        generateTileMapScript = GameObject.Find("Map").GetComponent<GenerateTileMap>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ChangeSprite(int newId)
    {
        GameObject gameObject = generateTileMapScript.prefabs[newId];
        transform.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
        id = newId;
    }
        public void OnMouseDown()
    {
            if(id != 1 && id != 3)
        ChangeSprite(2);
    }
}
