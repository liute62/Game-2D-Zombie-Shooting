using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	// Use this for initialization
	public GameObject[] Players;
	private GameObject CurrentPlayer;
	public float InitialSpeed = 1.0f;
	public enum Direction {Up,Down,Left,Right}
	public Direction direction = Direction.Down;
	void Start () {
		if (Players != null) {
			CurrentPlayer = Players[0];	
		}
		Invoke ("WaitStart",1.0f);
	}

	void WaitStart(){
		StartCoroutine(UpdateAction());
	}

	IEnumerator UpdateAction(){
		while (true) {
			switch(FindThePlayer(CurrentPlayer)){
			case 0:
				Up();
				break;
			case 1:
				Down();
				break;
			case 2:
				Left();
				break;
			case 3:
				Right();
				break;
			}
			yield return 0;		
		}
	}

	private int FindThePlayer(GameObject player){
		if (player == null) {
			player = CurrentPlayer;	
		}
		float zombie_x = transform.localPosition.x;
		float zombie_y = transform.localPosition.y;
		float player_x = player.transform.localPosition.x;
		float player_y = player.transform.localPosition.y;
		if(Mathf.Abs(zombie_x - player_x) > Mathf.Abs(zombie_y - player_y)){
			//means left or right
			if(zombie_x > player_x){
				//means zombie move to left
				return 2;
			}else{
				//means zombie move to right
				return 3;
			}
		}else{
			//means up or down
			if(zombie_y > player_y){
				//means zombie move to down
				return 1;
			}else{
				//means zombie move to up
				return 0;
			}
		}
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

}
