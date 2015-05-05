using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

	public TweenPosition mainMenu;
	public TweenPosition controlMenu;
	
	// Use this for initialization
	//	void Start () {
	//	
	//	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
	
	public void ClickControlButton(){
		mainMenu.PlayForward ();
		controlMenu.PlayForward ();
	}
	
	public void ClickBackButton(){
		mainMenu.PlayReverse ();
		controlMenu.PlayReverse ();
	}
}
