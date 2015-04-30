using UnityEngine;
using System.Collections;

public class GameAttribute : MonoBehaviour {

	public static GameAttribute instance;
	public long Score;
	public int Minute;
	public int Second;
	public long Gold;
	public int Clip;
	public int LeftClip;
	// Use this for initialization
	void Start () {
		Score = 0;
		Minute = 5;
		Second = 0;
		Gold = 0;
		Clip = 30;
		LeftClip = 90;
		instance = this;
	}

	// Update is called once per frame
	void Update () {
	
		Score++;
	}
}
