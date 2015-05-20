using UnityEngine;
using System.Collections;

public class ZombieHealth : MonoBehaviour {

	private class EnemyStats {
		public float []health = {
			100,
			200,
			300,
			400};
	}

	public int index;
	private float health;
	private long score;
	private int goldBase;
	void Start(){
		EnemyStats stats = new EnemyStats ();
		health = GameData.getZombieHealthByIndex (index);
		score = long.Parse(GameData.getZombieInitialScoreByIndex (index));
		goldBase = int.Parse (GameData.getZombieInitialGoldByIndex (index));
		//Debug.Log (goldBase);
	}



	public void DamageEnemy (int damage){
		if (GameMaster.isGodMode) {
			health = 0;
		}
		HitBackward();
		health -= damage;
		if (health <= 0) {
			SoundManager.instance.PlayingSound("zombieDieVoice");
			GameMaster.KillEnemy(this);
			GameAttribute.instance.Score += score;
			GameData.setScore((int)GameAttribute.instance.Score);
			long tmp =  GameMaster.ZombieGoldGenerate(goldBase);
			GameAttribute.instance.Gold += tmp;
			GameData.setGold((int)GameAttribute.instance.Gold);
		}
	}

	private void HitBackward(){
		ZombieController controller = gameObject.GetComponent<ZombieController>();
		controller.Backward();
	}
	
}
