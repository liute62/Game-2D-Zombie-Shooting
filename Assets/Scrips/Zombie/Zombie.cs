using UnityEngine;
using System.Collections;

public class Zombie : MonoBehaviour {

	public int index;
	public string name;
	public float height;
	public float width;
	public float attackAttr = 10;
	// Use this for initialization
	void Start () {
		attackAttr = GameData.getZombieInitialAttackByIndex (index);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
