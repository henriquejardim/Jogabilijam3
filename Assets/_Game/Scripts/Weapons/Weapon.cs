using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Weapon : MonoBehaviour {

    public InputManager input;
    public Transform firePoint;
    public WeaponData weaponData;
    public LineRenderer lr;
    private int layerMask = ~(1 << 11);

    private GameObject projectilePreFab;
    private float fireRate = 0.5f;
    private float projectileForce = 10;

    private float fireTime = 0f;

	// Use this for initialization
	void Start () {
        if (weaponData.scope) {
            lr = GetComponent<LineRenderer>();
            lr.transform.gameObject.SetActive(true);
        }

        projectilePreFab = weaponData.bulletPrefab;
        fireRate = weaponData.fireRate;
        projectileForce = weaponData.projectileForce;
	}
	
	// Update is called once per frame
	void Update () {
        Scope();

        fireRate = weaponData.fireRate;

        if ((input.FireButton()) && Time.time > fireTime + fireRate) {
            projectilePreFab = weaponData.bulletPrefab;
            projectileForce = weaponData.projectileForce;

            fireTime = Time.time;
            GameObject projectile = Instantiate(projectilePreFab, firePoint.position, firePoint.rotation);
            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * projectileForce);
        }
    }

    private void Scope() {
        if (!weaponData.scope) return;

        if (lr == null) {
            lr = GetComponent<LineRenderer>();
            lr.transform.gameObject.SetActive(true);
        }

        RaycastHit hit;
        Vector3 fwd = firePoint.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(firePoint.transform.position, fwd * 50, Color.green);
        if (Physics.Raycast(firePoint.transform.position, fwd, out hit, 50, layerMask)) {
            lr.SetPositions(new[] { transform.localPosition, transform.worldToLocalMatrix.MultiplyPoint(hit.point) });
        }
    }
}
