using UnityEngine;
using System.Collections;

public class GetItem : MonoBehaviour {

	public int ItemIndex = -1;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag ("Player")) {

			this.transform.position = new Vector3 (0, 0, -100);
			setItem (ItemIndex);
		}
	}

	private void setItem(int index){
		switch (index) {
			case 1: //get a pistol
			GameData.setCurrentWeaponIndex(1);
			GameData.setCurrentWeaponAmmoInitial(7);
			GameData.setCurrentWeaponAmmoLeft(35);
			GameData.setCurrentWeaponAmmoUsing(7);
			GameData.setCurrentWeaponAmmoInitialLeft(35);
			GameData.setCurrentWeaponAmmoInitialUsing(7);
			GameData.setCurrentWeaponPower(20);
			GameAttribute.instance.currentWeaponIndex = 1;
			GameAttribute.instance.weaponPower = GameData.Weapon.Pistol.power;
			break;
			case 2:
			GameData.setCurrentWeaponIndex(1);
			GameData.setCurrentWeaponAmmoInitial(30);
			GameData.setCurrentWeaponAmmoLeft(120);
			GameData.setCurrentWeaponAmmoUsing(30);
			GameData.setCurrentWeaponAmmoInitialLeft(120);
			GameData.setCurrentWeaponAmmoInitialUsing(30);
			GameData.setCurrentWeaponPower(35);
			GameAttribute.instance.currentWeaponIndex = 2;
			GameAttribute.instance.weaponPower = GameData.Weapon.Rifile.power;
			break;
		case 101: //get an ammo
			GameData.setCurrentWeaponAmmoInitial(GameData.getCurrentWeaponAmmoInitial());
			GameData.setCurrentWeaponAmmoLeft(GameData.getCurrentWeaponAmmoInitialLeft());
			GameData.setCurrentWeaponAmmoUsing(GameData.getCurrentWeaponAmmoInitialUsing());
			break;
		case 102:// get a key
			GameData.setCurrentLevelKeyGet(1);
			break;
		case 103://get an medikit
			GameData.setCurrentHealth(GameData.getMaxHealth());
			GameAttribute.instance.playerCurrentHealth = GameData.getCurrentHealth();
			break;
		case -100:
			GameData.setNextLevel();
			StartCoroutine("ChangeLevel",GameData.getCurrentLevelName());
			break;
		case -99:
			GameData.setNextLevel();
			StartCoroutine("ChangeLevel",GameData.getCurrentLevelName());
			break;
		case -98:
			if(GameMaster.level3_finished == true){
				GameMaster.level3_finished = false;
				this.transform.position = new Vector3 (0, 0, -100);
				GameData.setNextLevel();
				StartCoroutine("ChangeLevel",GameData.getCurrentLevelName());
			}else{
				this.transform.position = new Vector3 (127, -25, -5);
			}
			break;
		case -97:
			Debug.Log(-97);
			GameData.setNextLevel();
			StartCoroutine("ChangeLevel",GameData.getCurrentLevelName());
			break;
		case -70:
			Application.LoadLevel("Scene_shop");
			break;
		}
	}

	IEnumerator ChangeLevel (string level){
		float fadeTime = GameObject.FindWithTag ("GameMaster").GetComponent<Fading> ().beginFade (1);
		yield return new WaitForSeconds (fadeTime);
		Application.LoadLevel (level);
	}
}
