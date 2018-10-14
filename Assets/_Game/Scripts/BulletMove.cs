using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    public float speed = 5f;
 

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        transform.Translate(transform.forward * speed * Time.deltaTime);



    }

    private void MoveComplete() {
       
    }
}
