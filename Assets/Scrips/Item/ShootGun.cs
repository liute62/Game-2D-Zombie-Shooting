using UnityEngine;
using System.Collections;

public class ShootGun : MonoBehaviour {

	public float fireRate = 0;
	public int Damage = 150;
	public LayerMask whatToHit;
	public GameObject Bullet;
	float timeToFire = 0;
	Transform bulletSpawn;
	Transform bulletDirection;
	RaycastHit2D hit;
	ZombieHealth enemy;
	// Use this for initialization
	void Start () {
		bulletSpawn = transform.FindChild ("BulletSpawn");
		bulletDirection = transform.FindChild ("BulletDirection");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("w")){

		}

 		if (fireRate == 0) {
				if (Input.GetButtonDown ("Fire1")) {
						Shoot ();
				}

		} else {
			if(Input.GetButton ("Fire1") && Time.time > timeToFire){
				timeToFire = Time.time + 1/fireRate;
				Shoot ();
			}
		}
	}



	void Shoot () {
		Vector2 BulletSpawnPosition = new Vector2 (bulletSpawn.position.x, bulletSpawn.position.y);
		if (PlayerController.lastPressed == "a"){
			hit = Physics2D.Raycast (BulletSpawnPosition, new Vector2 (-1, 0), 100, whatToHit);
		}
		else if (PlayerController.lastPressed == "w"){
			hit = Physics2D.Raycast (BulletSpawnPosition, new Vector2 (0, 1), 100, whatToHit);
		}
		else if (PlayerController.lastPressed == "d"){
			hit = Physics2D.Raycast (BulletSpawnPosition, new Vector2 (1, 0), 100, whatToHit);
		}
		else if (PlayerController.lastPressed == "s"){
			hit = Physics2D.Raycast (BulletSpawnPosition, new Vector2 (0, -1), 100, whatToHit);
		}
		if (hit.collider != null) {
			Debug.Log ("hit something");
			enemy = hit.collider.GetComponent<ZombieHealth>();
			if (enemy != null){
				Debug.Log ("hit zombie1");
				StartCoroutine("WaitForBulletTouchZombie");
			}
		}
	}

	private IEnumerator WaitForBulletTouchZombie(){
		do{
		
		}while(1 == 1);
		enemy.DamageEnemy (Damage);
		yield return 0;
	}
}
