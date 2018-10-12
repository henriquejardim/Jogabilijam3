using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharController : MonoBehaviour {


    public float speed = 10f;
    public float dashSpeed = 30f;
    public float dashTime = 0.5f;

    private CharacterController cc;
    private float gravity = -10f;
    private Vector3 _inputs = Vector3.zero;

    private float timeForDash = 0f;

    private bool isDashing = false;

    // Use this for initialization
    void Start () {
        cc = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {

        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");

        _inputs *= speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && !isDashing) {
            timeForDash = 0f;
            isDashing = true;
        }

        if (timeForDash > dashTime) {
            isDashing = false;
        }

        if (isDashing) {
            timeForDash += Time.deltaTime;
            _inputs *= dashSpeed;
        }

        _inputs.y = gravity;

        cc.Move(_inputs);

    }
}
