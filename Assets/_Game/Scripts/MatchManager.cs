using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
        foreach (PlayerLife player in FindObjectsOfType<PlayerLife>())
        {
            player.OnDeath.AddListener(DeathPlayer);
        }       		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator RespawnPlayer(PlayerLife player)
    {
        yield return new WaitForSeconds(player.TotalTimeRespawn);
        player.gameObject.SetActive(true);
        var move = player.GetComponent<MoveCharController>();
        move.ResetMovement();

        player.OnRespawn.Invoke(player);
    }

    void DeathPlayer(PlayerLife player)
    {
        StartCoroutine("RespawnPlayer",player);
    }

}
