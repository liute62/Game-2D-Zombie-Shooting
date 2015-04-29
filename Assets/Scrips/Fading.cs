using UnityEngine;
using System.Collections;

public class Fading : MonoBehaviour {

	public Texture2D fadeTexture;
	public float fadeSpeed = 0.8f;

	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDirection = -1;

	void OnGUI (){
		alpha += fadeSpeed * fadeDirection * Time.deltaTime;
		alpha = Mathf.Clamp01 (alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeTexture);

	}

	public float beginFade (int direction){
		fadeDirection = direction;
		return (fadeSpeed);
	}

	void OnLevelWasLoaded (){
		beginFade (-1);
	}
}
