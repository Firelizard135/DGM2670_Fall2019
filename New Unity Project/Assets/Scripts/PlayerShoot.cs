using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Rigidbody rb;
    public FloatData xdirection;
    public FloatData zdirection;

    public GameObject sparksParticle;
    public FloatData shotCharge;
    public float shotChargeSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //Shoot
        if(Input.GetButton("Fire1") && shotCharge.value<shotCharge.maxValue) {
            //shotCharge.value += shotChargeSpeed;
            shotCharge.value = shotCharge.maxValue;
        }
        if(Input.GetButtonUp("Fire1")) {
            Shoot();
            shotCharge.value = 0;
        }
    }

    void Shoot() {
        Debug.Log("shoot");
        //Instantiate(projectile, rb.transform.position, rb.transform.rotation);
        //Instantiate(sparksParticle, rb.transform.position, rb.transform.rotation);
        //recoil
        rb.AddForce(-rb.rotation.x*300*shotCharge.value, 0.0f, -rb.rotation.z*300*shotCharge.value);
    }
}
