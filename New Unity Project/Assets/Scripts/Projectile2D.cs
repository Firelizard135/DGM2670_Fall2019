using System.Collections;
using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    private Rigidbody2D rb2D;

    public float lifeSpanSeconds = 1f;
    public float speed = 5f;
    public FloatData playerDirection;
    public FloatData shotCharge;
    public GameObject sparksParticle;

    //private Vector2 velocity;

    void Start()
    {
        StartCoroutine("DestroyTimer");
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.right * playerDirection.value * speed * 100f);
        shotCharge.value = 0;
        Instantiate(sparksParticle, transform.position, transform.rotation);
    }

    // void FixedUpdate()
    // {
    //     //Move Horizontally
    //     transform.position += speed;
    // }

    void OnTriggerEnter2D(Collider2D other){
        SelfDestruct();
    }

    // Destroy self after timer finishes
    public IEnumerator DestroyTimer() { 
        yield return new WaitForSeconds (lifeSpanSeconds);
        SelfDestruct();
    }

    public void SelfDestruct() {
        Instantiate(sparksParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}