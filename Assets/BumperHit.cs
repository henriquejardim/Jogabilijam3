using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperHit : MonoBehaviour {
    [SerializeField]
    private float    hitForce = 0f;

    private void OnCollisionEnter(Collision collision) {
        ApplyImpact(collision);
    }

    void ApplyImpact(Collision collision) {

        if (!collision.gameObject.CompareTag("Ball")) return;

        print("Bumper hit");
        var rb = collision.gameObject.GetComponent<Rigidbody>();

        rb.AddForce(((-1f) * collision.contacts[0].normal) * hitForce, ForceMode.Impulse);
    }
}
