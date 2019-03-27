using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour {

    public GameObject[] obstacles;

	// Use this for initialization
	void Start () {
        var r = Random.Range(0, obstacles.Length);

        obstacles[r].SetActive(true);

	}
	 
}
