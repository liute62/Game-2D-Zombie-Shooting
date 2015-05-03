using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {

	// Use this for initialization
	public GameObject PlayerPoint;
	private PlayerController Player;
	void Start () {
		Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	void Update () {
		//we need to calculate the Playerpoint's position according to Player's position.
		//PlayerPoint.transform.Translate(Vector2.up * Time.deltaTime * 0.001);
	}
}
