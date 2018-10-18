using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {

    public PlayerLife life;

    public GameObject respawnEffect;
    public GameObject shield;

    public MeshRenderer meshRenderer;

    public Material defaultMaterial;
    public Material hitMaterial;


    // Use this for initialization
    void Start () {
        life = GetComponent<PlayerLife>();

        if (life.OnRespawn == null)
            life.OnRespawn = new PlayerLife.PlayerEvent();

        life.OnRespawn.AddListener(OnPlayerRespawn);

        if (life.OnDamage == null)
            life.OnDamage = new PlayerLife.PlayerEvent();

        life.OnDamage.AddListener(OnDamage);
    }

    private void OnDamage(PlayerLife arg0) {
        meshRenderer.material = hitMaterial;
        StartCoroutine(SetDefaultMaterial());
    }

    IEnumerator SetDefaultMaterial() {
        yield return new WaitForSeconds(0.2f);
        meshRenderer.material = defaultMaterial;
    }

    // Update is called once per frame
    void Update () {
        shield.SetActive(life.invulnerable);
    }

    public void OnPlayerRespawn(PlayerLife player) {
        meshRenderer.material = defaultMaterial;
        StartCoroutine(Effect());
    }

     IEnumerator Effect() {
        yield return new WaitForSeconds(0.1f);
        print(life.gameObject.transform.position);
        Instantiate(respawnEffect, life.transform.position, respawnEffect.transform.rotation);
    }

}
