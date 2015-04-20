using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	public GameObject Target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float x = Target.transform.localPosition.x;
		float y = Target.transform.localPosition.y;
		float z = this.transform.localPosition.z;
		this.transform.localPosition = new Vector3 (x,y,z);
	}
}
