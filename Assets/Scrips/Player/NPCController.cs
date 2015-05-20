using UnityEngine;
using System.Collections;

public class NPCController : MonoBehaviour {
	
	public float InitialSpeed = 1.0f;
	public float TurnSpeed = 1.0f;
	private GameAttribute gameAttribute;
	private Vector3 moveDirection;
	public enum Direction {Up,Down,Left,Right}
	public Direction direction = Direction.Down;
	public enum State{Move,Shoot}
	public State state = State.Move;
	public static NPCController instance;
	float initialTime;
	int action;
	// Use this for initialization
	void Start () {
		initialTime = Time.time;
		instance = this;
		moveDirection = Vector3.right;
		gameAttribute = GameAttribute.instance;
		InitialSpeed = 5;
		Invoke ("WaitStart",0.2f);
	}
	
	void WaitStart(){
		StartCoroutine(UpdateAction());
	}
	
	IEnumerator UpdateAction(){
		while (true) {
			if(Time.time > initialTime + 0.1){
					action = WalkAround();
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

	private int WalkAround(){
		int action = Random.Range (0,4);
		if (action == 4) {
			action = 3;
		}
		return action;
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
