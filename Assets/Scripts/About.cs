using UnityEngine;
using System.Collections;

public class About : MonoBehaviour {

	public TweenPosition mainMenu;
	public TweenPosition aboutMenu;
	
	// Use this for initialization
	//	void Start () {
	//	
	//	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
	
	public void ClickAboutButton(){
		mainMenu.PlayForward ();
		aboutMenu.PlayForward ();
	}
	
	public void ClickBackButton(){
		mainMenu.PlayReverse ();
		aboutMenu.PlayReverse ();
	}
}
