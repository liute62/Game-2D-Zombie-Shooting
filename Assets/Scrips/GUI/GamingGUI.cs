using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamingGUI : MonoBehaviour {

	// Use this for initialization
	public Text ScoreText;
	public Text TimeText;
	public Text GoldText;
	public Text ClipText;
	private GameAttribute gameAttribute;
	void Start () {
		gameAttribute = GameAttribute.instance;
	}
	
	// Update is called once per frame
	void Update () {
		if(gameAttribute == null){
			gameAttribute = GameAttribute.instance;
		}
		ScoreText.text = gameAttribute.Score.ToString();
	}
}
