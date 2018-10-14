using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    public Material pink;

    float moveRate = 1.5f;

    private bool moving = false;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        if (moving) return;

        if (Input.GetKeyDown(KeyCode.W)) {
            moving = true;
            LeanTween.moveX(gameObject, transform.position.x + moveRate, 0.3f);

            LeanTween.rotate(gameObject, new Vector3(0, -90, 0), 0.3f)
                .setOnComplete(() => MoveComplete());
            
        }

        if (Input.GetKeyDown(KeyCode.S)) {
            moving = true;
            LeanTween.moveX(gameObject, transform.position.x - moveRate, 0.3f);

            LeanTween.rotate(gameObject, new Vector3(0, 90, 0), 0.3f)
                .setOnComplete(() => MoveComplete());

        }

        if (Input.GetKeyDown(KeyCode.A)) {
            moving = true;
            LeanTween.moveZ(gameObject, transform.position.z + moveRate, 0.3f);

            LeanTween.rotate(gameObject, new Vector3(0, -180, 0), 0.3f)
                .setOnComplete(() => MoveComplete());

        }


        if (Input.GetKeyDown(KeyCode.D)) {
            moving = true;
            LeanTween.moveZ(gameObject, transform.position.z - moveRate, 0.3f);

            LeanTween.rotate(gameObject, new Vector3(0, 0, 0), 0.3f)
                .setOnComplete(() => MoveComplete());

        }




    }

    private void MoveComplete() {
        moving = false;
    }
}
