using UnityEngine;
using UnityEngine.EventSystems;

public class SelectInput : MonoBehaviour {

    public EventSystem eventSystem;
    public GameObject selected;

    private bool buttonSelected = false;

	// Update is called once per frame
	void Update () {
		if ((Input.GetAxis("Vertical") != 0f) && !buttonSelected) {
            eventSystem.SetSelectedGameObject(selected);
            buttonSelected = true;
        }
	}

    private void OnDisable() {
        buttonSelected = false;
    }
}
