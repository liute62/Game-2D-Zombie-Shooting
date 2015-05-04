using UnityEngine;
using System.Collections;

public class MedKit : MonoBehaviour {

	private int addHealth = 25;
	private PlayerHealth condition;

	// Update is called once per frame
	void Update () {
		condition = PlayerHealth.instance;
	}

	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.name == "Player_1") {
			if (condition.health + addHealth > condition.fullHealth){
				condition.health = condition.fullHealth;
			}
			else{
				condition.health += addHealth;
			}
		}
	}
}
