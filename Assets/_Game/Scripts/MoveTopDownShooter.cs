using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTopDownShooter : MonoBehaviour {

    public Rigidbody rb;

    public float speed;
    public float dash;
    public float groudDistance;
    public LayerMask Ground;
    public GameObject rotationObject;

    public float hitForce = 5f;

    private Vector3 _inputs = Vector3.zero;
    private bool _isGrounded = true;
    public Transform _groundChecker;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //// _isGrounded = Physics.CheckSphere(_groundChecker.position, groudDistance, Ground, QueryTriggerInteraction.Ignore);


        _inputs = Vector3.zero;
        _inputs.x = Input.GetAxis("Horizontal");
        _inputs.z = Input.GetAxis("Vertical");
        // if (_inputs != Vector3.zero)
        //transform.forward = _inputs;

      
            rb.velocity = Vector3.zero;

     

        transform.position = new Vector3(rb.position.x, rb.position.y, rb.position.z);
        // rb.velocity = (transform.forward + _inputs * speed * Time.fixedDeltaTime);

        // rb.velocity = (_inputs * speed * Time.fixedDeltaTime);
        //if (Input.GetKeyDown(KeyCode.Space)) {
        //    //Vector3 dashVelocity = Vector3.Scale(_inputs, dash * new Vector3((Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime), 0, (Mathf.Log(1f / (Time.deltaTime * rb.drag + 1)) / -Time.deltaTime)));
        //    rb.AddForce(rotationObject.transform.forward.normalized * dash, ForceMode.Impulse);
        //}

        //rb.velocity = rb.velocity * 0.1f;
        //rb.AddForce(_inputs.normalized * speed, ForceMode.VelocityChange);
    }

    void FixedUpdate() {
        //rb.MovePosition(rb.position + _inputs.normalized * speed * Time.fixedDeltaTime);
        //rb.velocity = _inputs.normalized * speed * Time.fixedDeltaTime;4

        rb.transform.Translate(_inputs.normalized * speed * Time.fixedDeltaTime);
    }


}
