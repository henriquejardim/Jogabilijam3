using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerLife : MonoBehaviour {

    [System.Serializable]
    public class PlayerEvent : UnityEvent<PlayerLife> { }

    public PlayerEvent OnDeath;
    public PlayerEvent OnRespawn;
    public PlayerEvent OnDamage;

    public int TotalLife = 5;
    public int CurrentLife;

    public float TotalTimeRespawn = 3;
    public float TimeToRespawn;
    public float InvulnarableTime = 1f;
    public bool invulnerable;

    public int playerNumber = 1;

    Vector3 initialPosition;

    void Start () {
        initialPosition = transform.position;
        CurrentLife = TotalLife;
        if (OnDeath == null)
            OnDeath = new PlayerEvent();
        OnDeath.AddListener(Death);

        if (OnDamage == null)
            OnDamage = new PlayerEvent();
        OnDamage.AddListener(Damage);

        if (OnRespawn == null)
            OnRespawn = new PlayerEvent();
        OnRespawn.AddListener(Respawn);
	}

    void Damage(PlayerLife player)
    {
        CurrentLife--;
        print("Damage " + CurrentLife);

        //animação e audio de dano
        if (CurrentLife <= 0)
        {
            OnDeath.Invoke(this);
        }
    }

    void Death(PlayerLife player)
    {
        //animação e audio de morte
        player.gameObject.SetActive(false);
    }

    void Respawn(PlayerLife player)
    {
        //player.gameObject.SetActive(true)
        //animação e audio respawn
        player.transform.position = initialPosition;
        CurrentLife = TotalLife;
        player.invulnerable = true;
        StartCoroutine(EndInvulnerability(player));
    }

    private IEnumerator EndInvulnerability(PlayerLife player) {
        yield return new WaitForSeconds(InvulnarableTime);
        player.invulnerable = false;
    }

    public void ApplyDamage() {
        OnDamage.Invoke(this);
    }
}
