using UnityEngine;
using System.Collections;

public class Story : MonoBehaviour {

	public TweenPosition mainMenu;
	public TweenPosition storyMenu;
	
	// Use this for initialization
	//	void Start () {
	//	
	//	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
	
	public void ClickStoryButton(){
		mainMenu.PlayForward ();
		storyMenu.PlayForward ();
	}
	
	public void ClickBackButton(){
		mainMenu.PlayReverse ();
		storyMenu.PlayReverse ();
	}
}
