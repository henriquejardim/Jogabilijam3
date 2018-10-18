using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {

    public PlayerLife life;

    public GameObject respawnEffect;

	// Use this for initialization
	void Start () {
        life = GetComponent<PlayerLife>();

        if (life.OnRespawn == null)
            life.OnRespawn = new PlayerLife.PlayerEvent();

        life.OnRespawn.AddListener(OnPlayerRespawn);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPlayerRespawn(PlayerLife player) {
        StartCoroutine(Effect());
    }

     IEnumerator Effect() {
        yield return new WaitForSeconds(0.1f);
        print(life.gameObject.transform.position);
        Instantiate(respawnEffect, life.transform.position, respawnEffect.transform.rotation);
    }

}
