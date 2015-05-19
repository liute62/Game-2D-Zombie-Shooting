using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	public Sprite[] spritesUp;
	public Sprite[] spritesDown;
	public Sprite[] spritesLeft;
	public Sprite[] spritesRight;
	private Sprite[] tmp;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;
	public PlayerController controller;
	AudioClip movingAudio;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		switch (controller.direction) {
			case PlayerController.Direction.Up:
				tmp = spritesUp;
				break;
			case PlayerController.Direction.Down:
				tmp = spritesDown;
				break;
			case PlayerController.Direction.Left:
				tmp = spritesLeft;
				break;
			case PlayerController.Direction.Right:
				tmp = spritesRight;
				break;
			default:
				tmp = spritesDown;
			break;
		}
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % tmp.Length;
		spriteRenderer.sprite = tmp [index];
	}
}
