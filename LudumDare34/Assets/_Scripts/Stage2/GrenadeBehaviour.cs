using UnityEngine;
using System.Collections;

public class GrenadeBehaviour : MonoBehaviour {

    private Vector3 target;
    private float timer;
    private bool exploded;

	// Use this for initialization
	void Start () {
        timer = 0;
        exploded = false;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (exploded)
        {
            if (timer >= 0.2f)
            {
                Destroy(this.gameObject);
            }
        }
        // fuse
        else if (timer >= 1.5f)
            Explode();
        if (this.transform.position.y <= target.y)
            this.GetComponent<Rigidbody2D>().isKinematic = true;
    }

    public void Explode(){
        if (!exploded){
            exploded = true;
            this.gameObject.GetComponent<CircleCollider2D>().radius = 0.25f;
            this.gameObject.GetComponent<Animator>().enabled = true;
            this.gameObject.GetComponent<AudioSource>().Play();
            timer = 0;
        }
    }

    public void Launch(Vector3 _target){
        target = _target;
        float distance = (target - this.transform.position).x;
        this.GetComponent<Rigidbody2D>().AddForce(new Vector2(50.0f * distance, 0), ForceMode2D.Force);
    }
}
