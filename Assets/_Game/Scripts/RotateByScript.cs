using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByScript : MonoBehaviour {

    public InputManager input;
    public float speed = 10f;
    private Vector3 _inputs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _inputs = Vector3.zero;

        _inputs.z = input.RightStickVertical();
        _inputs.x = input.RightStickHorizontal();

        if (_inputs.magnitude < 0.1) return;

        print(_inputs);



        // Determine the target rotation.  This is the rotation if the transform looks at the target point.
        Quaternion targetRotation = Quaternion.LookRotation((transform.position + _inputs) - transform.position);

        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

        
    }
}
