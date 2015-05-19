using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float BulletSpeed = 100.0f;
	PlayerController.Direction direction;
	public int MoveTime = 1;
	float initialTime;
	float initialTimeNum;
	PlayerController controller;
	Zombie[] zombies;
	ZombieHealth zombieHealth;
	GameAttribute gameAttribute;
	// Use this for initialization
	void Start () {
		initialTime = Time.time;
		initialTimeNum = MoveTime;
		controller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		direction = controller.direction;
		gameAttribute = GameAttribute.instance;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log(direction.ToString());
		move();
		if(Time.time > initialTime + 0.5){
			initialTime = Time.time;
			if(initialTimeNum > 0){
				initialTimeNum --;
			}else{
				//now destroy it.
				GameMaster.KillBullet(this);
			}
		}
		checkCollide();
	}

	private void move(){
		if (direction == PlayerController.Direction.Down) {
			transform.eulerAngles = new Vector3(0,0,90);
			transform.Translate(-Vector2.right * Time.deltaTime * BulletSpeed);
		}if (direction == PlayerController.Direction.Up) {
			transform.eulerAngles = new Vector3(0,0,90);
			transform.Translate(Vector2.right  * Time.deltaTime* BulletSpeed);

		}if (direction == PlayerController.Direction.Left) {
			transform.eulerAngles = new Vector3(0,0,0);
			transform.Translate(-Vector2.right * Time.deltaTime * BulletSpeed);
		}if (direction == PlayerController.Direction.Right) {
			transform.eulerAngles = new Vector3(0,0,0);
			transform.Translate(Vector2.right* Time.deltaTime * BulletSpeed);
		}
	}

	private void checkCollide(){
		checkForZombie ();
		//checkForDoor ();
	}

	private void checkForZombie(){
		GameObject[] zombieObjects = GameObject.FindGameObjectsWithTag("Zombie");
		zombies = new Zombie[zombieObjects.Length];
		for(int i = 0;i != zombieObjects.Length;i++){
			zombies[i] = zombieObjects[i].GetComponent<Zombie>();
			if(checkRange(zombies[i].transform.position,transform.position,zombies[i].width/2,zombies[i].height/2)){
				Debug.Log("Hit it");
				zombieHealth = zombieObjects[i].GetComponent<ZombieHealth>();
				zombieHealth.DamageEnemy(gameAttribute.weaponPower);
				GameMaster.KillBullet(this);
			}
		}
	}

	private void checkForDoor(){
		GameObject[] doors = GameObject.FindGameObjectsWithTag("Door");
		for (int i = 0; i != doors.Length; i++) {
			if(checkRange(doors[i].transform.position,transform.position,1,2)){
				Debug.Log("Hit the door");
			}
		}
	}

	private bool checkRange(Vector3 vec1,Vector3 vec2,float x_range,float y_range){
		if(Mathf.Abs(vec1.x - vec2.x)< x_range && Mathf.Abs(vec1.y - vec2.y) < y_range){
			return true;
		}
		return false;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.CompareTag("Door")) {
			Debug.Log ("Hit Door");
		}
	}
}
