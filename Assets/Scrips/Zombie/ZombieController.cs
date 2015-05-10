using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	// Use this for initialization
	private GameObject[] Players;
	private GameObject CurrentPlayer;
	public float InitialSpeed = 1.0f;
	public enum Direction {Up,Down,Left,Right}
	public Direction direction = Direction.Down;
	float initialTime;
	int action;
	public float AttackRange;
	public float AttackIntervel; // the next attack should be after how many seconds 
	float attackInitialTime;
	void Start () {
		Players = GameObject.FindGameObjectsWithTag("Player");
		CurrentPlayer = Players[0];
		Invoke ("WaitStart",1.0f);
	}

	void WaitStart(){
		initialTime = Time.time;
		action = 0;
		attackInitialTime = Time.time;
		StartCoroutine(UpdateAction());
	}

	IEnumerator UpdateAction(){
		while (true) {
			CheckAttackRange(CurrentPlayer);
			if(Time.time > initialTime + 0.1){
				action = FindThePlayer(CurrentPlayer);
				initialTime = Time.time;
			}
			switch(action){
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

	private void CheckAttackRange(GameObject player){
		if (player == null) {
			player = CurrentPlayer;	
		}
		float zombie_x = transform.localPosition.x;
		float zombie_y = transform.localPosition.y;
		float player_x = player.transform.localPosition.x;
		float player_y = player.transform.localPosition.y;
		if (Mathf.Abs (zombie_x - player_x) < AttackRange && Mathf.Abs (zombie_y - player_y) < AttackRange) {
			//Check the attack intervel
			if(Time.time > attackInitialTime + AttackIntervel){
				//Now Attack the player
				GameAttribute.instance.playerCurrentHealth -= this.GetComponentInParent<Zombie>().attackAttr;
				if(GameAttribute.instance.playerCurrentHealth <= 0){
					GameAttribute.instance.playerCurrentHealth = 0;
					GameMaster.GameOver();
				}
				attackInitialTime = Time.time;
			}
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

	public void Backward(){
		Vector3 pos = transform.position;
		if(direction == Direction.Up){
			this.transform.position = new Vector3(pos.x,pos.y-1,pos.z);
		}else if(direction == Direction.Down){
			this.transform.position = new Vector3(pos.x,pos.y+1,pos.z);
		}else if(direction == Direction.Left){
			this.transform.position = new Vector3(pos.x+1,pos.y,pos.z);
		}else if(direction == Direction.Right){
			this.transform.position = new Vector3(pos.x-1,pos.y,pos.z);
		}
	}
}
