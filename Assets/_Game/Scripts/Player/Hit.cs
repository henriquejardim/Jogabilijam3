using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hit : MonoBehaviour {
    public Rigidbody rb;

    public bool isDashing = false;
    public float hitForce = 5;
    public float hitForceWhenDashing = 25;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {
        var rigid = collision.collider.gameObject.GetComponent<Rigidbody>();
        if (rigid == null) return;
        print("HIT");
        rigid.AddForce(((-1f) * collision.contacts[0].normal) * (isDashing ?  hitForceWhenDashing : hitForce), ForceMode.VelocityChange);
    }
}
