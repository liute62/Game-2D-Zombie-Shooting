using UnityEngine;
using System.Collections;

public class Zombie1Health : MonoBehaviour {

	public class EnemyStats {
		public float health = 100;
	}

	public EnemyStats stats = new EnemyStats ();

	public void DamageEnemy (int damage){
		stats.health -= damage;
		if (stats.health <= 0) {
			GameMaster.KillEnemy(this);
		}
	}
}
