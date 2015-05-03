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

	void Start(){
		EnemyStats stats = new EnemyStats ();
		health = stats.health[index];
	}



	public void DamageEnemy (int damage){
		HitBackward();
		health -= damage;
		if (health <= 0) {
			GameMaster.KillEnemy(this);
		}
	}

	private void HitBackward(){
		ZombieController controller = gameObject.GetComponent<ZombieController>();
		controller.Backward();
	}
}
