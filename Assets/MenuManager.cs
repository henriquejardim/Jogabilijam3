using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public GameManager gameManager;
    public Text suporteJogador1;
    public Text suporteJogador2;

    public Button jogar;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        jogar.enabled = gameManager.ControllersBinded();    
	}

    public void OnJogar() {
        gameManager.Play();
    }
    
}
