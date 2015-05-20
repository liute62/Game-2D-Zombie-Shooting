using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;
	public bool isGameOver;
	public static GameMaster instance;
	public static bool isGodMode = false;
	public static int level3_zombie_killed = 0;
	public static bool level3_finished = false;
	// Use this for initialization
	void Start () {
		instance = this;
		isGameOver = false;
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("GameMaster").GetComponent<GameMaster>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		int level = GameData.getCurrentLevel ();
		if (level == 3) {
			if(level3_zombie_killed == 30){
				level3_zombie_killed = 0;
				level3_finished = true;
			}
		}
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

	public static void GameOver(){
		GameObject.FindGameObjectWithTag ("GameOver").GetComponent<GameOver> ().show ();
		SoundManager.instance.PlayingSound ("Scream");
		Debug.Log ("GameOver");
		GameMaster.instance.isGameOver = true;
	}

	public static void GameWin(){
		GameObject.FindGameObjectWithTag ("GameWin").GetComponent<GameOver> ().missionComplete ();
		GameMaster.instance.isGameOver = true;
	}

	public static void Reset(){
	
	}

	public static long ZombieGoldGenerate(int baseValue){
		float random = Random.Range (0, baseValue);
		return (long)random;
	}
}
