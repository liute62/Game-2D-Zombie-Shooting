using UnityEngine;
using System.Collections;

public class DoorRemoval : MonoBehaviour {

	// Use this for initialization
	public bool canBeRemoval = false;
	int times = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnCollisionEnter2D (Collision2D col){
		//Debug.Log (times);
		if (col.gameObject.name == "Player_1") {

		if (canBeRemoval) {

				Destroy (this.gameObject);
		
		}else{
			int getKey = GameData.getCurrentLevelKeyGet();
			if(getKey == 1){
					Destroy(this.gameObject);	
			 }
		 }
	  }
	}
}
