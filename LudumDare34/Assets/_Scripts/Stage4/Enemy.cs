using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    GenerateTileMap tilemapScript;
    GameObject currentTarget = null;
    bool isAtTree = false;
    float speed = 1.0f;
	// Use this for initialization
	void Start () {
        tilemapScript = GameObject.Find("Map").GetComponent<GenerateTileMap>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isAtTree)
            return;
        Vector2 currentPos = new Vector2(transform.position.x,transform.position.y);
        Vector2 targetPos = new Vector2();
        if (currentTarget == null)
        {
            currentTarget = tilemapScript.enemySpawn;
            return;
        }
        else
        {

            targetPos = new Vector2(currentTarget.transform.position.x, currentTarget.transform.position.y);

            //New target
            if (Vector2.Distance(currentPos, targetPos) < 0.3f)
            {
                currentTarget = tilemapScript.getNextTilePath(currentTarget);
                if (currentTarget == tilemapScript.tree)
                {
                    isAtTree = true;
                }
            }
            //Move
            else
            {
                Vector3 tempPos = (currentTarget.transform.position - transform.position).normalized;
                transform.GetComponent<Rigidbody2D>().velocity = new Vector2(tempPos.x, tempPos.y) * speed;
            }
        }
        Vector3 diff = currentTarget.transform.position - transform.position;
        transform.rotation = GetRotation(diff);

	}
    public static  Quaternion GetRotation(Vector3 vector)
    {

        float rotation = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
        return Quaternion.Euler(0.0f, 0.0f, rotation);
    }
}
