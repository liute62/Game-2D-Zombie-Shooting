using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public void NewGame(){
		GameData.Reset ();
		Application.LoadLevel ("CollapsedBuildingLevel");
	}

	public void ShopBack(){
		Application.LoadLevel ("StreetLevel");
	}

	public void BackMenu(){
		Application.LoadLevel ("Scene_menu");
	}
}
