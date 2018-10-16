using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletHit : MonoBehaviour {

    public float hitForce;

    private void OnCollisionEnter(Collision collision) {

        if (!collision.collider.gameObject.CompareTag("Player")) return;

        var move = collision.collider.gameObject.GetComponent<MoveCharController>();
        if (move == null) 
          move = collision.collider.gameObject.GetComponentInParent<MoveCharController>();

        if (move == null) return;
        
        print("Player HIT");

        move.AddImpact(((-1f) * collision.contacts[0].normal), hitForce);

       
    }

}
