using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ScoreEvent : UnityEvent<int> { }
public class Ball : MonoBehaviour {
    
    public ScoreEvent OnScore;
    [Range(1,2)] 
    public int PlayerNumber;
	// Use this for initialization
	void Start () {
        if (OnScore == null)
            OnScore = new ScoreEvent();
        OnScore.AddListener(MakeScore);

	}
	
	void MakeScore(int numberPlayer)
    {
        // animação e audio de score
        GameObject.Destroy(this.gameObject);
    }
}
