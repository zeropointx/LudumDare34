using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {
    public GameObject bulletPrefab;
    EnemyHandler enemyHandler;
    GameObject spawnedRadius = null;
    public GameObject radiusPrefab;
    GameObject target = null;
    float range = 5.0f;
    float shootTimer = 0.0f;
    float shootDelay = 10.0f;
    bool shot = false;
	// Use this for initialization
	void Start () {
        enemyHandler = GameObject.Find("EnemyHandler").GetComponent<EnemyHandler>();
	}
	
	// Update is called once per frame
	void Update () {
        if (shot)
            shootTimer += Time.deltaTime;
        if (shootTimer >= shootDelay)
            shot = false;
        UpdateShooting();


	}
    void OnMouseOver()
    {
        if(spawnedRadius == null)
        {
            spawnedRadius = (GameObject)GameObject.Instantiate(radiusPrefab,transform.position,transform.rotation);
            spawnedRadius.transform.localScale = new Vector3(range, range);
        }
    }
    void OnMouseExit()
    {
        if (spawnedRadius == null)
            return;
        GameObject.Destroy(spawnedRadius);
        spawnedRadius = null;
    }
    void UpdateShooting()
    {
        if(target == null)
        {
            target = GetClosestEnemy();
            if (target == null)
                return;
        }
        if(!shot)
        {
            Shoot();
        }

    }
    GameObject GetClosestEnemy()
    {
        for( int i = enemyHandler.enemies.Count -1; i > -1; i--)
        { 
            GameObject tempEnemy = enemyHandler.enemies[i];
            if (tempEnemy == null)
                continue;
            Vector3 tempEnemyPos = tempEnemy.transform.position;
            if(Vector2.Distance(new Vector2(tempEnemyPos.x,tempEnemyPos.y),new Vector2(transform.position.x,transform.position.y)) < (range * 0.64f ) / 2)
            {
                return tempEnemy;
            }
       
        }
        //If no find
        return null;
    }
    void Shoot()
    {
        Vector3 bulletTarget = target.transform.position - transform.position;
        GameObject bulletInstance = (GameObject)GameObject.Instantiate(bulletPrefab, transform.position, Enemy.GetRotation(target.transform.position - transform.position));
        bulletInstance.GetComponent<Bullet>().target = bulletTarget;
        shot = true;
        shootTimer = 0.0f;
    }
}
