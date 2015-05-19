using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

	public TweenPosition storyMenu;
	public TweenPosition loadGame;
	
	// Use this for initialization
	//	void Start () {
	//	
	//	}
	
	// Update is called once per frame
	//	void Update () {
	//	
	//	}
	
	public void ClickLoadGameButton(){
		storyMenu.PlayReverse ();
		loadGame.PlayForward ();
	}
	
	public void ClickBackButton(){
		storyMenu.PlayForward ();
		loadGame.PlayReverse ();
	}
}
