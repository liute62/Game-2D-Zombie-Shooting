using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool activeInput = false;
	public bool keyInputEnable = true;
	public bool mouseInputEnable = true;
	public float InitialSpeed = 1.0f;
	public float TurnSpeed = 1.0f;
	private GameController gameController;
	private GameAttribute gameAttribute;
	private Vector3 moveDirection;
	public enum Direction {Up,Down,Left,Right}
	public Direction direction = Direction.Down;
	public GameObject GunEffect;
	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right;
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
			}if(mouseInputEnable){
				//mouseInput();
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

	private void mouseInput(){
		// 1
		Vector3 currentPosition = transform.position;
		// 2
		if (Input.GetButton ("Fire1")) {
		// 3
		Vector3 moveToward = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		// 4
			moveDirection = moveToward - currentPosition;
			moveDirection.z = 0;
			moveDirection.Normalize ();
		}
		float targetAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;
		transform.rotation =
			Quaternion.Slerp( transform.rotation,
			                 Quaternion.Euler( 0, 0, targetAngle ),
			                 TurnSpeed * Time.deltaTime );
	}

	private void Up(){
		this.transform.Translate (Vector2.up * Time.deltaTime * InitialSpeed);
		direction = Direction.Up;
	}

	private void Down(){
		this.transform.Translate (Vector2.up * Time.deltaTime * InitialSpeed * (-1));
		direction = Direction.Down;
	}

	private void Left(){
		this.transform.Translate (Vector2.right * Time.deltaTime * InitialSpeed * (-1));
		direction = Direction.Left;
	}

	private void Right(){
		this.transform.Translate (Vector2.right * Time.deltaTime * InitialSpeed);
		direction = Direction.Right;
	}

	private void Shot(){
		initEffect (GunEffect);
	}

	private GameObject initEffect(GameObject prefab){
		GameObject go = (GameObject)Instantiate (prefab, transform.position, Quaternion.identity);
		go.transform.parent = transform;
		go.transform.localPosition = new Vector3 (0, 0, transform.localPosition.z);	
		return go;
	}
}
