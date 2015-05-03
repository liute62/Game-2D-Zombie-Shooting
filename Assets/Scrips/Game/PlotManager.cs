using UnityEngine;
using System.Collections;

public class PlotManager : MonoBehaviour {

	GameObject Player;
	int PlotIndex;
	bool isFinished;
	// Use this for initialization
	void Start () {
		isFinished = false;
		PlotIndex = 0;
		Player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		switch (PlotIndex) {
			case 0:
			StartCoroutine("GameBegin");
			PlotIndex = -1;
			break;
		}
	}

	IEnumerator GameBegin(){
		while (!isFinished) {
			Player.transform.Translate(Vector2.up * Time.deltaTime * 2);

		}
		yield return 0;
	}
}
