using UnityEngine;
using System.Collections;

public class ZombieSpawn : MonoBehaviour {

	public GameObject[] Zombies;
	public int SpawnTimeIntervel;
	public int MaxSpawnNumber;
	public bool EnableSpawn = true;
	private float initialTime;
	private int spawnTimeNum;
	// Use this for initialization
	void Start () {
		initialTime = Time.time;
		spawnTimeNum = SpawnTimeIntervel;
	}
	
	// Update is called once per frame
	void Update () {
		if (spawnTimeNum > 0) {
			if(Time.time > initialTime + 1){
				initialTime = Time.time;
				spawnTimeNum--;
			}
		}if (spawnTimeNum == 0) {
			CreateAZombie();
			spawnTimeNum = SpawnTimeIntervel;
		}
	}
	
	private void CreateAZombie(){
		GameObject zombie = Zombies [0];
		GameObject newZombie = (GameObject)Instantiate (zombie,transform.position,Quaternion.identity);
		newZombie.transform.position = new Vector3(RandomX(),RandomY(),-5);
	}

	private float RandomX(){
		return Random.Range (-10,10);
	}

	private float RandomY(){
		return Random.Range (-10,10);
	}
}
