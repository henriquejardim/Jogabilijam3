using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialOnCollision : MonoBehaviour {

    public Material defaultMaterial;
    public Material onCollisionMaterial;

    public MeshRenderer meshRenderer;

    private void Start() {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    IEnumerator SetDefaultMaterial() {
        yield return new WaitForSeconds(0.2f);
        if (meshRenderer.gameObject.activeSelf)
            meshRenderer.material = defaultMaterial;
    }

    private void OnCollisionEnter(Collision collision) {
        meshRenderer.material = onCollisionMaterial;
        StartCoroutine(SetDefaultMaterial());
    }
}
