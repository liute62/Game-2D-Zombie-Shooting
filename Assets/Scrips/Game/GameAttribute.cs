using UnityEngine;
using System.Collections;

public class GameAttribute : MonoBehaviour {

	public static GameAttribute instance;
	public long Score;
	public int Minute;
	public int Second;
	public long Gold;
	public int initialClip;
	public int Clip;
	public int LeftClip;
	private float initialTime;
	public int weaponPower;
	// Use this for initialization
	void Start () {
		instance = this;
		Score = 0;
		Minute = 5;
		Second = 0;
		Gold = 0;
		initialClip = 30;
		Clip = initialClip;
		LeftClip = 90;
		weaponPower = 10;
		initialTime = Time.time;
	}

	// Update is called once per frame
	void Update () {
		Score++;
		timeUpdate ();
		Gold++;
	}

	private void timeUpdate(){
		if (Time.time > initialTime + 1) {
				
			if(Second > 0){
				Second--;
			   }
			else{
				if(Minute > 0){
					Minute--;
					Second = 59;
				}else{
					//that means minute = 0 and second = 0;time is over
				}
			}
			initialTime = Time.time;
		}
	}

	public static void clipUpdate(){
		if(GameAttribute.instance != null){
			GameAttribute tmp = GameAttribute.instance;
			if(tmp.Clip > 0){
				tmp.Clip --;
			}else{
				//means player need to change the magazine
				if(tmp.LeftClip > 0){
					if(tmp.LeftClip >= tmp.initialClip){
						tmp.LeftClip -= tmp.initialClip;
						tmp.Clip = tmp.initialClip;
					}else{
						tmp.Clip = tmp.LeftClip;
						tmp.LeftClip = 0;
					}
				}else{
					//that means bullet is no left now.
				}
			}
		}
	}
}
