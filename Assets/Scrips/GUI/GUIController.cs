using UnityEngine;
using System.Collections;

public class GUIController : MonoBehaviour {

	public void NewGame(){
		GameData.Reset ();
		Application.LoadLevel ("CollapsedBuildingLevel");
	}
}
