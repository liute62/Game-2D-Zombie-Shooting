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
			times++;
		}
		if(times == 3){
			canBeRemoval = true;
		}if (canBeRemoval) {

			if (col.gameObject.name == "Player_1") {
				Destroy (this.gameObject);
			}
		}
	}
}
