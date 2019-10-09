using System.Collections;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float lifeSpanSeconds = 1f;

    void Start()
    {
        StartCoroutine("DestroyTimer");
    }

    // Destroy self after timer finishes
    public IEnumerator DestroyTimer(){ 
        yield return new WaitForSeconds (lifeSpanSeconds);
        Destroy(gameObject);
    }
}
