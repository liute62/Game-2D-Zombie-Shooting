using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	// Use this for initialization
	void Start () {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GM").GetComponent<GameMaster>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void KillEnemy (Zombie1Health enemy) {
		Destroy (enemy.gameObject);
	}
}
