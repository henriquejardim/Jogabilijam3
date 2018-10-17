using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	public PlayerLife Player1;
	public PlayerLife Player2;
	public float TimeRespawn = 3f;


	[HideInInspector]
	public bool GameActive;
	[HideInInspector]
	public float CurrentRespawn1;
	[HideInInspector]
	public float CurrentRespawn2;



	void Start () {
		CurrentRespawn1 = TimeRespawn;
		CurrentRespawn2 = TimeRespawn;
	}
	
	// Update is called once per frame
	void Update () {
		if (!Player1.gameObject.activeSelf && CurrentRespawn1 >= 0)
			CurrentRespawn1 -= Time.deltaTime;

		if (!Player2.gameObject.activeSelf && CurrentRespawn2 >= 0)
			CurrentRespawn2 -= Time.deltaTime;

		if (!Player1.gameObject.activeSelf && CurrentRespawn1 <= 0)
		{
			Player1.gameObject.SetActive(true);
			Player1.Respawn();
			CurrentRespawn1 = TimeRespawn;
		}
		if (!Player2.gameObject.activeSelf && CurrentRespawn2 <= 0)
		{
			Player2.gameObject.SetActive(true);
			Player2.Respawn();
			CurrentRespawn2 = TimeRespawn;
		}
		
	}
}
