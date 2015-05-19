using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	private bool activeInput = false;
	public bool keyInputEnable = true;
	public bool mouseInputEnable = true;
	public float InitialSpeed = 1.0f;
	public float TurnSpeed = 1.0f;
	private GameAttribute gameAttribute;
	private Vector3 moveDirection;
	public enum Direction {Up,Down,Left,Right}
	public Direction direction = Direction.Down;
	public enum State{Move,Shoot}
	public State state = State.Move;
	public GameObject GunEffect;
	public static PlayerController instance;
	public static string lastPressed;
	public GameObject BulletPrefab;
	public bool isPlayerHasWeapon;
	public bool isWeaponHasAmmo;
	// Use this for initialization
	void Start () {
		instance = this;
		moveDirection = Vector3.right;
		gameAttribute = GameAttribute.instance;
		InitialSpeed = GameData.getPlayerInitialSpeed ();
	    if (GameData.getCurrentWeaponIndex () > 0) {
			isPlayerHasWeapon = true;
		} else {
			isPlayerHasWeapon = false;
		}

		if (GameData.getCurrentWeaponAmmoLeft() > 0 || GameData.getCurrentWeaponAmmoUsing() > 0) {
			isWeaponHasAmmo = true;
		} else {
			isWeaponHasAmmo = false;
		}

		Invoke ("WaitStart",0.2f);
	}

	void WaitStart(){
		StartCoroutine(UpdateAction());
	}

	IEnumerator UpdateAction(){
		while (true) {
			if (GameData.getCurrentWeaponIndex () > 0) {
				isPlayerHasWeapon = true;
			} else {
				isPlayerHasWeapon = false;
			}

			if (GameData.getCurrentWeaponAmmoLeft() > 0 || GameData.getCurrentWeaponAmmoUsing() > 0) {
				isWeaponHasAmmo = true;
			} else {
				isWeaponHasAmmo = false;
			}

			if(keyInputEnable){		
				KeyInput();
			}if(mouseInputEnable){
				//mouseInput();
			}
			if(GameMaster.instance.isGameOver == true){
				break;
			}
			yield return 0;
		}
	}

	private void KeyInput(){

		if (Input.anyKeyDown) {
			//SoundManager.instance.PlayingSound ("footstep");

			activeInput = true;		
		}
			if (Input.GetKey (KeyCode.A)) {
			lastPressed = "a";
			state = State.Move;
			Left ();
			activeInput = false;
		} else if (Input.GetKey (KeyCode.D)) {
			lastPressed = "d";
			state = State.Move;
			Right ();
			activeInput = false;
		} else if (Input.GetKey (KeyCode.W)) {
			lastPressed = "w";
			state = State.Move;
			Up ();
			activeInput = false;
		} else if (Input.GetKey (KeyCode.S)) {
			lastPressed = "s";
			state = State.Move;
			Down ();
			activeInput = false;
		} else if (Input.GetKey (KeyCode.L)) {
			lastPressed = "L";
		} else if (Input.GetKey (KeyCode.I)) {
			if (lastPressed.Equals("L")) {
				lastPressed = "LI";
			}
		} else if (Input.GetKey (KeyCode.U)) {
			if(lastPressed.Equals("LI")){
				lastPressed = "LIU";
				if(GameMaster.isGodMode == true){
					GameMaster.isGodMode = false;
					Debug.Log("God Mode Disable");
					InitialSpeed = 20;
				}else{
					GameMaster.isGodMode = true;
					Debug.Log("God Mode Enable");
					InitialSpeed = GameData.getPlayerInitialSpeed();
				}
			}
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
		//initEffect (GunEffect);
		if (isPlayerHasWeapon) {
			if(isWeaponHasAmmo){
				initPrefab (BulletPrefab, new Vector3 (0, -0.05f, 0));
				GameAttribute.clipUpdate ();
			}
		}
	}

	private GameObject initPrefab(GameObject prefab,Vector3 pos){
		GameObject go = (GameObject)Instantiate (prefab, transform.position, Quaternion.identity);
		go.transform.parent = transform;
		go.transform.localPosition = new Vector3 (pos.x,pos.y,pos.z);	
		return go;
	}

	private GameObject initEffect(GameObject prefab){
		GameObject go = (GameObject)Instantiate (prefab, transform.position, Quaternion.identity);
		go.transform.parent = transform;
		go.transform.localPosition = new Vector3 (0, 0, transform.localPosition.z);	
		return go;
	}
}
