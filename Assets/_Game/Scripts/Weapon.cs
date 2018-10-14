using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    public InputManager input;

    public GameObject projectilePreFab;
    public float fireRate = 0.5f;
    public Transform firePoint;
    public float projectileSpeed = 10;

    private float fireTime = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if ((Input.GetButton("Fire1") || input.FireButton()) && Time.time > fireTime + fireRate) {
            fireTime = Time.time;
            GameObject projectile =  Instantiate(projectilePreFab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileSpeed);
        }
	}
}
