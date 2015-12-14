using UnityEngine;
using System.Collections;

public class GrenadeThrowing : MonoBehaviour {

    public GameObject grenade;
    public Texture2D cursorTexture;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit != null && hit.collider != null)
            {
                if (hit.collider.gameObject.name == this.name)
                {
                    GameObject clone = Instantiate(grenade);
                    clone.name = "Grenade";
                    clone.transform.position = new Vector3(9, 7, 0);
                    clone.GetComponent<GrenadeBehaviour>().Launch(hit.point);
                    clone.transform.parent = transform.parent.FindChild("Grenades");
                    clone.GetComponent<Animator>().enabled = false;
                }
            }
        }
	}
    
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
