using UnityEngine;
using System.Collections;

public class grapperScript : MonoBehaviour
{
    Vector3 position;
    public GameObject apple;
    public float minY, maxY, minX, maxX;
    bool hPlus, hMinus, vPlus, vMinus;
    public bool horizontalMode, verticalMode;
    public float speed;

    // Use this for initialization
    void Start()
    {
        horizontalMode = true;
        verticalMode = false;
        hPlus = false;
        hMinus = false;
        vPlus = false;
        vMinus = false;
    }

    // Update is called once per frame
    void Update()
    {
        position = transform.localPosition;

        checkCollision();
        move();


    }

    void checkCollision()
    {
        if (horizontalMode)
        {
            //vPlus = false;
            //vMinus = false;

            if (position.x >= maxX)
            {
                hMinus = true;
                hPlus = false;
            }
            if (position.x <= minX)
            {
                hMinus = false;
                hPlus = true;

            }
        }
        else
        {
            //hPlus = false;
            //hMinus = false;

            if (position.y >= maxY)
            {
                vMinus = true;
                vPlus = false;
            }
            if (position.y <= minY)
            {
                vMinus = false;
                vPlus = true;
            }
        }
    }

    void move()
    {
        if (horizontalMode)
        {
            if (hPlus)
                transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);

            if (hMinus)
                transform.position = new Vector3(transform.position.x - speed, transform.position.y, transform.position.z);
        }

        if (verticalMode)
        {
            if (vPlus)
                transform.position = new Vector3(transform.position.x, transform.position.y + speed, transform.position.z);

            if (vMinus)
                transform.position = new Vector3(transform.position.x, transform.position.y - speed, transform.position.z);
        }

        }

}


