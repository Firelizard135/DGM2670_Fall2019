using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    // Player Movement Variables
    public float moveSpeed;
    private float xdirection;
    private float zdirection;
    public float horizontalDrag;

    // Jumping
    public float jumpForce;

    private Rigidbody rb;
    public GameObject jumpParticle;
    public FloatData jumpData;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //animator.SetBool("isHeavy",false);
        //rb.mass = lesserMass;
    }


    void FixedUpdate() {
        //rb.velocity.x = rb.velocity.x*(1-horizontalDrag);
        rb.velocity = new Vector3(rb.velocity.x*(1-horizontalDrag), rb.velocity.y, rb.velocity.z*(1-horizontalDrag));
    }

    void Update()
    {
        // Movement
        xdirection = Input.GetAxis("Horizontal")*moveSpeed;
        zdirection = Input.GetAxis("Vertical")*moveSpeed;
        //rb.velocity = new Vector2(direction*moveSpeed/rb.mass, rb.velocity.y);
        rb.AddForce(xdirection, 0.0f, zdirection);


        // Variable Height Jump
        if(Input.GetButtonDown("Jump") && jumpData.value>0) {
            Instantiate(jumpParticle, rb.transform.position, Quaternion.identity);
            Jump();
        }

        if(Input.GetButtonUp("Jump")) {
            jumpData.value--;

            if(rb.velocity.y > 0) { //cut upwards momentum on button release
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            }
        }

        void Jump() {
            rb.AddForce(0.0f, jumpForce*10, 0.0f);
        }

    }
}
