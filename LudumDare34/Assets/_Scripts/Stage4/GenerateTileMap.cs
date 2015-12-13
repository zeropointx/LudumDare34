using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class GenerateTileMap : MonoBehaviour {
    public GameObject[] prefabs;
    public GameObject[] parentGameobjects;
    public List<GameObject> enemyPath = new List<GameObject>();
    public List<GameObject> roads = new List<GameObject>();
    int height  = 0, width = 0;
    public TextAsset textfile;
    public GameObject enemySpawn;
    public GameObject tree;
    int[] tilemap;
    float tileSize = 0.64f;
	// Use this for initialization
	void Start () {
        GenerateTilemap();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void GenerateTilemap()
    {

        string textString = textfile.text;
        string[] lines = textString.Split('\n');
        for(int i = 0; i < lines.Length; i++)
        {
            lines[i] = lines[i].Replace("\r","");

            if (width != 0 && width != lines[i].Length)
            {
                Debug.Log("ERROR! Tilemap width doesn't match! LINE: "+ (i +1) );
                string line = lines[i];
                Debug.Log(line[line.Length- 1]);
                return;
            }
            width = lines[i].Length;  
        }
        height = lines.Length;
        createTiles(lines);
        GenerateEnemyPath();
    }
    void createTiles(string[] textData)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                
                GameObject gobject = prefabs[int.Parse(""+textData[j][i])];
                Vector3 pos = new Vector3(i * 0.64f, -j * 0.64f);
                Quaternion quat = new Quaternion();
                GameObject instance = (GameObject)GameObject.Instantiate(gobject,pos,quat);
                if (int.Parse("" + textData[j][i]) == 3)
                    enemySpawn = instance;
                else if(int.Parse("" + textData[j][i]) == 2)
                    tree = instance;
                instance.transform.parent = parentGameobjects[int.Parse("" + textData[j][i])].transform;
                instance.transform.position += instance.transform.parent.position;
                if (int.Parse("" + textData[j][i]) == 1 || int.Parse("" + textData[j][i]) == 3)
                roads.Add(instance);
            }
        }
    }
    void GenerateEnemyPath()
    {
        GameObject current = null;
        GameObject last = null;
      
        //Find enemyspawn
        for( int i = 0; i < roads.Count; i++)
        {
            
            if(roads[i].GetComponent<Tile>().id == 3)
            {
                enemyPath.Add(roads[i]);
                current = roads[i];
                break;
            }
        }
        int index = 0;
        while(current != tree)
        {
            if (index > 500)
                break;
            var tileObjects = getCloseTiles(current);
            if(tileObjects.Count > 2)
            {
                for( int i = 0; i < tileObjects.Count; i++)
                {
                    //If more than 2 objects (4) then go same direction that your last gameobject was at
                    Vector3 direction = current.transform.position - last.transform.localPosition;
                    if(tileObjects[i].transform.localPosition == current.transform.localPosition + direction)
                    {
                        last = current;
                        current = tileObjects[i];
                        enemyPath.Add(tileObjects[i]);
                        continue;
                    }
                }
            }
            else
            {
                for( int i = 0; i < tileObjects.Count; i++)
                {
                    if (tileObjects[i] == last)
                        continue;
                    else
                    {
                        last = current;
                        current = tileObjects[i];
                        enemyPath.Add(tileObjects[i]);
                        break;
                    }
                }
            }
            index++;
        }
        enemyPath.Add(tree);

    }
    //Gets gameobjects within 1 unit away
    List<GameObject> getCloseTiles(GameObject g)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        Vector3 localPos = g.transform.localPosition;
        for(int x = -1; x < 2; x++)
        {
            for(int y = -1; y < 2; y++)
            {
                //dont calculate corners
                if (Vector2.Distance(localPos, new Vector2(x * tileSize + localPos.x, y * tileSize + localPos.y)) > (tileSize +0.05f ) )
                   continue;

                GameObject gameObject = getGameObject(x * tileSize + localPos.x, y * tileSize + localPos.y);

                if (gameObject == null || gameObject == g)
                    continue;
                Tile tile = gameObject.GetComponent<Tile>();
                //if it is road
                if (tile.id == 1 || tile.id == 3)
                    gameObjects.Add(gameObject);

            }
        }


        return gameObjects;

    }
    GameObject getGameObject(float x, float y)
    {
        for( int i = 0; i < roads.Count; i++)
        {
            float compareToX = roads[i].transform.localPosition.x;
            float compareToY = roads[i].transform.localPosition.y;
            if (Vector2.Distance(new Vector2(x,y), new Vector2(compareToX,compareToY)) < 0.05f)
                return roads[i];
        }
        return null;
    }
   public GameObject getNextTilePath(GameObject g)
    {
       for( int i = 0; i < enemyPath.Count; i++)
       {
           if (enemyPath[i] == g)
               return enemyPath[i + 1];
       }
       return null;
    }
}
