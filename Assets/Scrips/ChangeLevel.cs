using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	IEnumerator OnTriggerEnter2D (Collider2D col){
			Debug.Log ("made into if statement");
			float fadeTime = GameObject.FindWithTag ("GM").GetComponent<Fading> ().beginFade (1);
			yield return new WaitForSeconds (fadeTime);
			Debug.Log ("afterwards");
			Application.LoadLevel (Application.loadedLevel + 1);

	}
	
}
