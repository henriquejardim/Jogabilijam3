using System;
using System.Collections;
using UnityEngine;

public class PocketEffect : MonoBehaviour {

    public Pocket pocket;

    public GameObject effectPlayer1;
    public GameObject effectPlayer2;

    // Use this for initialization
    void Start () {
        pocket = GetComponent<Pocket>();
        pocket.OnPocket.AddListener(PlayEffect);
    }

    private void PlayEffect(int playerNumber) {
        StartCoroutine(Effect(playerNumber));
    }


    IEnumerator Effect(int playerNumber) {
        yield return new WaitForSeconds(0.1f);
        print(gameObject.transform.position);
        Instantiate(playerNumber == 1 ? effectPlayer1 : effectPlayer2 , gameObject.transform.position + new Vector3(0, 3.3f), gameObject.transform.rotation);
    }




}
