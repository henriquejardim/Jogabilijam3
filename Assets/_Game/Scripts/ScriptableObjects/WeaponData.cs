using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Weapon/New", order = 1)]
public class WeaponData : ScriptableObject {
    public GameObject bulletPrefab;
    public float fireRate;
    public float projectileForce;
}
