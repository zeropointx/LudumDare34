using UnityEngine;
using System.Collections;

public class GrenadeBehaviour : MonoBehaviour {

    public float fuseTime = 1.25f;
    public float explosionTime = 0.15f;
    public static int totalCount = 0;

    private Vector3 target;
    private float timer;
    private bool exploded;

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
            if (timer >= explosionTime)
            {
                totalCount--;
                totalCount = Mathf.Max(totalCount, 0);
                //Debug.Log("Grenades: " + totalCount.ToString());
                Destroy(this.gameObject);
            }
        }
        // fuse
        else if (timer >= fuseTime)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Grenade")
        {
            Explode();
        }
    }
}
