using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int health = 100;
	public int fullHealth = 100;
	public static PlayerHealth instance;

	// Use this for initialization
	void Start () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
