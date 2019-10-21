using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public FloatData playerDirection;

    public GameObject projectile;
    public FloatData shotCharge;
    public float shotChargeSpeed;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Shoot
        if(Input.GetButton("Fire1") && shotCharge.value<shotCharge.maxValue) {
            shotCharge.value += shotChargeSpeed;
        }
        if(Input.GetButtonUp("Fire1")) {
            Shoot();
        }
    }

    void Shoot() {
        Instantiate(projectile, rb2D.transform.position, rb2D.transform.rotation);
        //recoil
        rb2D.AddForce(transform.right * -playerDirection.value*300*shotCharge.value);
    }
}
