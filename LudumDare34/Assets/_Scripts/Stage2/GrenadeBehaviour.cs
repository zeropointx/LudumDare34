using UnityEngine;
using System.Collections;

public class GrenadeBehaviour : MonoBehaviour {

    private Vector3 target;
    private float timer;
    private bool exploded;
    private static int totalCount;

	// Use this for initialization
	void Start () {
        timer = 0;
        exploded = false;
        totalCount++;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (exploded)
        {
            if (timer >= 0.15f)
            {
                totalCount--;
                Destroy(this.gameObject);
            }
        }
        // fuse
        else if (timer >= 1.15f)
            Explode();

        if (this.transform.position.y <= target.y)
        {
            this.GetComponent<Rigidbody2D>().isKinematic = true;
            this.transform.position = target;
        }
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
        float angleToPoint = Mathf.Atan2(target.y - this.transform.position.y, target.x - this.transform.position.x);
        float distanceFactor = 1.0f / 16.0f;
        float angleCorrection = (Mathf.PI * 0.18f) * (distance * distanceFactor);
        float power = 550.0f;
        Vector2 velocity = new Vector2(Mathf.Cos(angleToPoint + angleCorrection) * power, Mathf.Sin(angleToPoint + angleCorrection) * power);
        this.GetComponent<Rigidbody2D>().AddForce(velocity, ForceMode2D.Force);
    }

    public static int GetCount() {
        return totalCount;
    }
}
