using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class OnPocketEvent : UnityEvent<int> { }
public class Pocket : MonoBehaviour {

    public OnPocketEvent OnPocket;

	// Use this for initialization
	void Start () {
        if (OnPocket == null)
            OnPocket = new OnPocketEvent();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        print("Colidiu");
        var ball = other.GetComponent<Ball>();
        if (ball != null)
        {
            ball.OnScore.Invoke(ball.PlayerNumber);
            if (OnPocket != null)
                OnPocket.Invoke(ball.PlayerNumber);
            return;
        }
        var life = other.gameObject.GetComponent<PlayerLife>();

        if (life == null)
            life = other.gameObject.GetComponentInParent<PlayerLife>();

        if (life == null) return;

        life.OnDeath.Invoke(life);
        if (OnPocket != null)
            OnPocket.Invoke(life.playerNumber);
    }



     
}
