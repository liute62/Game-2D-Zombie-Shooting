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
	public float playerMaxHealth;
	public float playerCurrentHealth;
	public bool isWeaponChange;
	public int currentWeaponIndex;
	// Use this for initialization
	void Start () {
		instance = this;
		Score = long.Parse(GameData.getScore());
		Gold = GameData.getGold();
		initialClip = GameData.getCurrentWeaponAmmoInitial();
		Clip = GameData.getCurrentWeaponAmmoUsing();
		LeftClip = GameData.getCurrentWeaponAmmoLeft();
		playerMaxHealth = GameData.getMaxHealth();
		playerCurrentHealth = GameData.getCurrentHealth();
		initialByLevel();
		initialTime = Time.time;
		currentWeaponIndex = GameData.getCurrentWeaponIndex();
	}

	void initialByLevel(){
		int index = GameData.getCurrentLevel();
		switch(index){
			case 1:
				Minute = GameData.Level_1.General.timeMinute;
				Second = GameData.Level_1.General.timeSecond;
				weaponPower = GameData.getCurrentWeaponPower();
				break;
			case 2:
				Minute = GameData.Level_2.General.timeMinute;
				Second = GameData.Level_2.General.timeSecond;
				weaponPower = GameData.getCurrentWeaponPower();
				break;   
			case 3:
				Minute = GameData.Level_3.General.timeMinute;
				Second = GameData.Level_3.General.timeSecond;
				weaponPower = GameData.getCurrentWeaponPower();	
				break;
			default:
			break;
		}
	}

	// Update is called once per frame
	void Update () {
		timeUpdate ();
		Clip = GameData.getCurrentWeaponAmmoUsing();
		LeftClip = GameData.getCurrentWeaponAmmoLeft();
		initialClip = GameData.getCurrentWeaponAmmoInitial();

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
		if (GameMaster.isGodMode) {
			return;
		}
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
			GameData.setCurrentWeaponAmmoUsing(tmp.Clip);
			GameData.setCurrentWeaponAmmoLeft(tmp.LeftClip);
		}
	}
}
