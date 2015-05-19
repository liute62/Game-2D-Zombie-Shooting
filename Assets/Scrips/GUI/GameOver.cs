using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	public Image bg;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void show(){
		Color color = new Color (255,255,255);
		bg.color = color;
		GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		cameraObject.transform.position = new Vector3 (1.62f,-1.56f,-1230);
	}

	public void missionComplete(){
		Color color = new Color (255,255,255);
		bg.color = color;
		GameObject cameraObject = GameObject.FindGameObjectWithTag("MainCamera");
		cameraObject.transform.position = new Vector3 (1.62f,-1.56f,-1230);
	}
}
