using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Hit : MonoBehaviour {
    public Rigidbody rb;

    public float hitForce = 5;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision) {

        print("hihi");
        if (collision.gameObject.CompareTag("Ball"))
            print("Ball");

        if (collision.collider.CompareTag("Ball"))
            print("Ball2");

        if (collision.collider.gameObject.CompareTag("Ball"))
            print("Ball3");


        var rigid = collision.collider.gameObject.GetComponent<Rigidbody>();
        if (rigid == null) return;
        print("HIT");
        rigid.AddForce(((-1f) * collision.contacts[0].normal) * hitForce, ForceMode.VelocityChange);
    }
}
