using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pocket : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        print("Colidiu");
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ball.OnScore.Invoke(ball.PlayerNumber);
            return;
        }
        var life = other.gameObject.GetComponent<PlayerLife>();

        if (life == null)
            life = other.gameObject.GetComponentInParent<PlayerLife>();

        if (life == null) return;

        life.OnDeath.Invoke(life);
    }
}
