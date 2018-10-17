using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour {

	// Use this for initialization

	public int TotalLife = 5;
	public int CurrentLife;
	public bool IsActive;
	public float hitForce = 5;

	Vector3 initialPosition;
	void Start () {
		initialPosition = transform.position;
		CurrentLife = TotalLife;

	}

	// Update is called once per frame
	void Update () { }

	public void Respawn () {
		
		IsActive = true;
		CurrentLife = TotalLife;
		transform.position = initialPosition;
	}

	void Death () {
		IsActive = false;
		gameObject.SetActive (false);
	}

	public void Damage(int dano)
	{
		CurrentLife -= dano;
		if (CurrentLife <= 0)
			Death();	
	}

	
	

}