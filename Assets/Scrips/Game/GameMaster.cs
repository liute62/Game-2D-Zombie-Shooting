using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;

	// Use this for initialization
	void Start () {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public static void KillEnemy (ZombieHealth enemy) {
		Destroy (enemy.gameObject);
	}

	public static void KillEnemy(Zombie enemy){
		Destroy (enemy.gameObject);
	}

	public static void KillBullet(Bullet bullet){
		Destroy(bullet.gameObject);
	}
}
