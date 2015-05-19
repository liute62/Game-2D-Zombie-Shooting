using UnityEngine;
using System.Collections;

public class Arcade: MonoBehaviour {

	public TweenPosition mainMenu;
	public TweenPosition arcadeMenu;

	// Use this for initialization
//	void Start () {
//	
//	}
	
	// Update is called once per frame
//	void Update () {
//	
//	}

	public void ClickArcadeButton(){
		mainMenu.PlayForward ();
		arcadeMenu.PlayForward ();
	}

	public void ClickBackButton(){
		mainMenu.PlayReverse ();
		arcadeMenu.PlayReverse ();
	}
}
