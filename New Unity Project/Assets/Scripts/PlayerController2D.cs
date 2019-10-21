using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public FloatData playerDirection;

    // Player Movement Variables
    public float moveSpeed;
    private float xdirection;
    public float horizontalDrag;

    // Jumping
    public FloatData jumpData;
    public float jumpForce;
    public GameObject jumpParticle;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        //animator.SetBool("isHeavy",false);
        //rb2D.mass = lesserMass;
    }


    void FixedUpdate() {
        //rb2D.velocity.x = rb2D.velocity.x*(1-horizontalDrag);
        rb2D.velocity = new Vector2(rb2D.velocity.x*(1-horizontalDrag), rb2D.velocity.y);

        //Face Direction
        if ( Mathf.Abs(xdirection) > 0.1f) {
            playerDirection.value = xdirection;
            
        }
    }

    void Update()
    {
        // Movement
        xdirection = Input.GetAxis("Horizontal")*moveSpeed;
        //rb2D.velocity = new Vector2(direction*moveSpeed/rb2D.mass, rb2D.velocity.y);
        rb2D.AddForce(rb2D.transform.right * xdirection * 100f);
        
        // Variable Height Jump
        if(Input.GetButtonDown("Jump") && jumpData.value>0) {
            Instantiate(jumpParticle, rb2D.transform.position, Quaternion.identity);
            Jump();
        }

        if(Input.GetButtonUp("Jump")) {
            jumpData.value--;

            if(rb2D.velocity.y > 0) { //cut upwards momentum on button release
                rb2D.velocity = new Vector2(rb2D.velocity.x, rb2D.velocity.y * 0.5f);
            }
        }
    }

    void Jump() {
        rb2D.AddForce(rb2D.transform.up * jumpForce*10);
    }

}
