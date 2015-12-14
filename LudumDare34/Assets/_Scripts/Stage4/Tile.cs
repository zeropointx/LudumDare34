using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
        Vector3 localPos = transform.position;

        GameObject newInstance = (GameObject)GameObject.Instantiate(gameObject, localPos, transform.rotation);
        newInstance.transform.position = localPos;
        newInstance.transform.parent = generateTileMapScript.parentGameobjects[newId].transform;
        GameObject.Destroy(transform.gameObject);
       // transform.GetComponent<SpriteRenderer>().sprite = gameObject.GetComponent<SpriteRenderer>().sprite;
       // id = newId;
    }
        public void OnMouseDown()
    {
        if (GlobalVariables.globalVariables.money >= 30)
        {
            if (id != 1 && id != 3 & id != 4)
            {
                ChangeSprite(4);
                GlobalVariables.globalVariables.reduceMoney(30);

            }

        }
    }




}
