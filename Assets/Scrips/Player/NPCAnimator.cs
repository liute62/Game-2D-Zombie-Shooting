using UnityEngine;
using System.Collections;

public class NPCAnimator : MonoBehaviour {
	
	public Sprite[] spritesUp;
	public Sprite[] spritesDown;
	public Sprite[] spritesLeft;
	public Sprite[] spritesRight;
	private Sprite[] tmp;
	public float framesPerSecond;
	private SpriteRenderer spriteRenderer;
	public NPCController controller;
	AudioClip movingAudio;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<Renderer>() as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		switch (controller.direction) {
		case NPCController.Direction.Up:
			tmp = spritesUp;
			break;
		case NPCController.Direction.Down:
			tmp = spritesDown;
			break;
		case NPCController.Direction.Left:
			tmp = spritesLeft;
			break;
		case NPCController.Direction.Right:
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
