using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTimer : MonoBehaviour {
    
    public float startTime = 4f;

    public float elapsedTime;
    public Text m_timerText;
	// Use this for initialization
	void Start () {
        elapsedTime = startTime;
        m_timerText = GetComponent<Text>();
	}

    private void OnEnable() {
        elapsedTime = startTime;
    }

    // Update is called once per frame
    void Update () {
        startTime -= Time.deltaTime;
        UpdateTimer();

        if (startTime <= 1f)
            m_timerText.gameObject.SetActive(false);
	}

    void UpdateTimer() {
        m_timerText.text = ((int)startTime).ToString();
    }
}
