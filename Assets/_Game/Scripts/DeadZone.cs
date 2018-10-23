using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeadZone : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        var player = collision.gameObject.GetComponentInParent<PlayerLife>();
        if (player != null)
            player.OnDeath.Invoke(player);
    }
}
