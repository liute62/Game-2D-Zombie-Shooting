using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool activeInput = false;
	public bool keyInputEnable = true;
	public float InitialSpeed = 1.0f;
	private GameController gameController;
	private GameAttribute gameAttribute;
	// Use this for initialization
	void Start () {
		Invoke ("WaitStart",0.2f);
	}

	void WaitStart(){
		StartCoroutine(UpdateAction());
	}

	void initial(){
		gameAttribute = GameAttribute.Instance ();
	}

	IEnumerator UpdateAction(){
		while (true) {
			if(keyInputEnable){		
				KeyInput();
			}
			yield return 0;
		}
	}

	private void KeyInput(){

		if (Input.anyKeyDown) {
			activeInput = true;		
		}
	
			if(Input.GetKey(KeyCode.A)){
				Left();
				activeInput = false;
			}else if(Input.GetKey(KeyCode.D)){
				Right();
				activeInput = false;
			}else if(Input.GetKey(KeyCode.W)){
				Up();
				activeInput = false;
			}else if(Input.GetKey(KeyCode.S)){
				Down();
				activeInput = false;
			}

		if (activeInput) {
			if(Input.GetKey(KeyCode.Space)){	
				Shot();
				activeInput = false;
			}
		}

	}

	private void Up(){
		this.transform.Translate (Vector2.up * Time.deltaTime * InitialSpeed);
	}

	private void Down(){
		this.transform.Translate (Vector2.up * Time.deltaTime * InitialSpeed * (-1));
	}

	private void Left(){
		this.transform.Translate (Vector2.right * Time.deltaTime * InitialSpeed * (-1));
	}

	private void Right(){
		this.transform.Translate (Vector2.right * Time.deltaTime * InitialSpeed);
	}

	private void Shot(){
		
	}
}
