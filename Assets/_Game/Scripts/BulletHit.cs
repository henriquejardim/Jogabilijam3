using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletHit : MonoBehaviour {

    public float hitForce;
    public bool applyImpact = true;

    private void OnCollisionEnter(Collision collision) {

        if (!collision.collider.gameObject.CompareTag("Player")) return;

        ApplyImpact(collision);
        ApplyDamage(collision);

       
    }

    private void ApplyDamage(Collision collision) {
        var life = collision.collider.gameObject.GetComponent<PlayerLife>();
        if (life == null)
            life = collision.collider.gameObject.GetComponentInParent<PlayerLife>();

        life.ApplyDamage();

    }

    private void ApplyImpact(Collision collision) {

        if (!applyImpact) return;

        var move = collision.collider.gameObject.GetComponent<MoveCharController>();
        if (move == null)
            move = collision.collider.gameObject.GetComponentInParent<MoveCharController>();

        if (move == null) return;

        print("Player HIT");

        move.AddImpact(((-1f) * collision.contacts[0].normal), hitForce);
    }

}
