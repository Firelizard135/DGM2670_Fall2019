using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float lifeSpanSeconds = 1f;
    public float speed;
    public Vector3Data playerDirection;
    public FloatData shotCharge;
    public GameObject sparksParticle;

    private Vector3 velocity;

    void Start()
    {
        StartCoroutine("DestroyTimer");
        velocity = playerDirection.value.normalized*shotCharge.value*speed/100;
        shotCharge.value = 0;
    }

    void FixedUpdate()
    {
        //Move Horizontally
        transform.position += velocity;
    }

    void OnTriggerEnter(Collider other){
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