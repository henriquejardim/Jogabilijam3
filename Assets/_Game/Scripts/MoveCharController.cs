using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharController : MonoBehaviour {

    public InputManager input;
    public float speed = 10f;
    public float dashSpeed = 30f;
    public float dashTime = 0.5f;
    public Hit hit;

    private CharacterController cc;
    private float gravity = -10f;
    private Vector3 _inputs = Vector3.zero;

    private float timeForDash = 0f;

    private bool isDashing = false;
    private bool dashPressed;

    void Start () {
        cc = GetComponent<CharacterController>();
        hit = GetComponentInChildren<Hit>();
    }
	
	void Update () {
        
        _inputs = Vector3.zero;
        _inputs.x = input.LeftStickHorizontal();
        _inputs.z = input.LeftStickVertical();

        _inputs *= speed * Time.deltaTime;
        
        if (input.DashButtonDown() && !isDashing) {
            timeForDash = 0f;
            isDashing = true;
        }

        if (timeForDash > dashTime) {
            isDashing = false;
        }

        if (isDashing) {
            timeForDash += Time.deltaTime;
            _inputs.Normalize();
            _inputs *= dashSpeed;
        }

        hit.isDashing = isDashing;

        _inputs.y = gravity;

        cc.Move(_inputs);

        // apply the impact force:
        if (impact.magnitude > 0.2) cc.Move(impact * Time.deltaTime);
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);

    }

    private float mass = 3.0f;
    private Vector3 impact = Vector3.zero;

    public void AddImpact(Vector3 dir, float force) {
        dir.Normalize();
        if (dir.y < 0) dir.y = -dir.y; // reflect down force on the ground
        impact += dir.normalized * force / mass;
    }
}
