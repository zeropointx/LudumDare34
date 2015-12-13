using UnityEngine;
using System.Collections;

public class GrenadeThrowing : MonoBehaviour {

    public GameObject grenade;

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
                    clone.transform.position = hit.point;
                    clone.transform.parent = transform.parent.FindChild("Grenades");
                    clone.GetComponent<Animator>().enabled = false;
                }
            }
        }
	}
}
