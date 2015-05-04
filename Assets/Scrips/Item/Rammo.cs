using UnityEngine;
using System.Collections;

public class Rammo : MonoBehaviour {
	
	private int Ammo = 15;
	private GameAttribute game;
	
	void Update (){
		game = GameAttribute.instance;
	}
	
	
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.name == "Player_1") {
			if (game.LeftClip + 15 > 45){
				
			}
			else{
				game.LeftClip += Ammo;
				Destroy (this.gameObject);
			}
		}
		
	}
}