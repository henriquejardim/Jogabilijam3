using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamamge : MonoBehaviour {

	public int Damage = 1;
	private void OnCollisionEnter(Collision other) {
		Debug.ClearDeveloperConsole();
		if (other.gameObject.CompareTag("Player"))
		{
			Debug.Break();
			var player = other.gameObject.GetComponentInParent<PlayerLife>();
			player.Damage(Damage);
			
		}
	}
}
