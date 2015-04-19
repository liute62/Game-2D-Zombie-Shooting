using UnityEngine;
using System.Collections;

public class GameAttribute : MonoBehaviour {

	public static GameAttribute instance;
	// Use this for initialization
	void Start () {
		instance = this;
	}

	public static GameAttribute Instance(){
		return instance;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
