using UnityEngine;

public class Weapon : MonoBehaviour {

    public InputManager input;
    public Transform firePoint;
    public WeaponData weaponData;

    private GameObject projectilePreFab;
    private float fireRate = 0.5f;
    private float projectileForce = 10;

    private float fireTime = 0f;

	// Use this for initialization
	void Start () {
        projectilePreFab = weaponData.bulletPrefab;
        fireRate = weaponData.fireRate;
        projectileForce = weaponData.projectileForce;
	}
	
	// Update is called once per frame
	void Update () {
        if ((input.FireButton()) && Time.time > fireTime + fireRate) {
            fireTime = Time.time;
            GameObject projectile =  Instantiate(projectilePreFab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileForce);
        }
	}
}
