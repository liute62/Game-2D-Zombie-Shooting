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
			GameData.setCurrentWeaponAmmoInitial(30);
			GameData.setCurrentWeaponAmmoLeft(30);
			GameData.setCurrentWeaponAmmoUsing(30);
			GameAttribute.instance.currentWeaponIndex = 1;
			break;
		case 101: //get an ammo
			GameData.setCurrentWeaponAmmoInitial(30);
			GameData.setCurrentWeaponAmmoLeft(90);
			GameData.setCurrentWeaponAmmoUsing(30);
			break;
		}
	}
}
