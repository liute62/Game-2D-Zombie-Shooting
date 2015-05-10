using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		Debug.Log ("Ontrigger");
		if (other.gameObject.Equals (player)) {
			//if it is the player get the key
			Destroy(this.gameObject);
		}
	 }

  }
