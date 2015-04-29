using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public float BulletSpeed = 10.0f;
	PlayerController.Direction direction;
	public GameObject Player;
	int moveNum = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.instance != null) {
			if(PlayerController.instance.state == PlayerController.State.Shoot)	{
				direction = PlayerController.instance.direction;
				move();
			}else{
				Vector3 pos =  Player.transform.position;
				transform.position = new Vector3(pos.x,pos.y-0.15f,0);
			}
		}

	}

	private void move(){
		moveNum++;
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
}
