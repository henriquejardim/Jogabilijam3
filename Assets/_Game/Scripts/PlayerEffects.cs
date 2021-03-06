﻿using System.Collections;
using UnityEngine;

public class PlayerEffects : MonoBehaviour {

    public PlayerLife life;
    public AudioSource dash;

    [SerializeField]
    public GameObject respawnEffect;
    [SerializeField]
    public GameObject shield;

    [SerializeField]
    public GameObject deathEffect;

    public MeshRenderer meshRenderer;

    public Material defaultMaterial;
    public Material hitMaterial;


    // Use this for initialization
    void Start() {
        dash = GetComponent<AudioSource>();

        life = GetComponent<PlayerLife>();

        if (life.OnRespawn == null)
            life.OnRespawn = new PlayerLife.PlayerEvent();

        life.OnRespawn.AddListener(OnPlayerRespawn);

        life.OnDamage.AddListener(OnDamage);
    }

    public void OnDeath() {
        if (deathEffect == null) return;
        if(life == null) {
            print("LIFE NULL");
            return;
        }
        PlayEffect(deathEffect);
    }

    private void OnDamage(PlayerLife life) {
        if (!gameObject.activeSelf) return;
        meshRenderer.material = hitMaterial;
        StartCoroutine(SetDefaultMaterial());
    }

    IEnumerator SetDefaultMaterial() {
        yield return new WaitForSeconds(0.2f);
        if (meshRenderer.gameObject.activeSelf)
            meshRenderer.material = defaultMaterial;
    }

    // Update is called once per frame
    void Update() {
        if (gameObject.activeSelf)
            shield.SetActive(life.invulnerable);
    }

    public void OnPlayerRespawn(PlayerLife player) {
        meshRenderer.material = defaultMaterial;
        StartCoroutine(Effect(respawnEffect));
    }

    IEnumerator Effect(GameObject effect) {
        yield return new WaitForSeconds(0.1f);
        print(life.gameObject.transform.position);
        PlayEffect(effect);
    }

    public void PlayEffect(GameObject effect) {
        Instantiate(effect, life.transform.position, effect.transform.rotation);
    }

    public void PlayDashAudio() {
        dash.Play();
    }

}
