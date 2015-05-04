using UnityEngine;
using System.Collections;

public class Sammo : MonoBehaviour {
	
	private int Ammo = 10;
	private GameAttribute game;
	
	void Update (){
		game = GameAttribute.instance;
	}
	
	
	void OnTriggerEnter2D (Collider2D col){
		if (col.gameObject.name == "Player_1") {
			if (game.LeftClip + 10 > 30){
				
			}
			else{
				game.LeftClip += Ammo;
				Destroy (this.gameObject);
			}
		}
		
	}
}