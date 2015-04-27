using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

	public int damagePerShot = 20;                  // The damage inflicted by each bullet.
	public float timeBetweenBullets = 0.15f;        // The time between each shot.
	public float range = 100f;                      // The distance the gun can fire.
	float timer;                                    // A timer to determine when to fire.
	Ray2D shootRay;                                   // A ray from the gun end forwards.
	RaycastHit2D shootHit;                    // A raycast hit to get information about what was hit.
	int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
	ParticleSystem gunParticles;                    // Reference to the particle system.
	LineRenderer gunLine;                           // Reference to the line renderer.
	AudioSource gunAudio;                           // Reference to the audio source.
	Light gunLight;                                 // Reference to the light component.
	float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.
	Vector2 init;
	Vector2 aimed;
	void Awake ()
	{
		// Create a layer mask for the Shootable layer.
		shootableMask = LayerMask.GetMask ("Shootable");
		
		// Set up the references.
		gunParticles = GetComponent<ParticleSystem> ();
		gunLine = GetComponent <LineRenderer> ();
		gunAudio = GetComponent<AudioSource> ();
		gunLight = GetComponent<Light> ();
	}
	
	// Update is called once per frame
	void Update () {
		init = new Vector2 (transform.position.x,transform.position.y);
		aimed = new Vector2 (transform.position.x + 2.0f, transform.position.y);
		// Add the time since Update was last called to the timer.
		timer += Time.deltaTime;
		#if !MOBILE_INPUT
		// If the Fire1 button is being press and it's time to fire...
		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
		{
			// ... shoot the gun.
			Shoot ();
		}
		#else
		// If there is input on the shoot direction stick and it's time to fire...
		if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
		{
			// ... shoot the gun
			Shoot();
		}
		#endif
		// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
		if(timer >= timeBetweenBullets * effectsDisplayTime)
		{
			// ... disable the effects.
			DisableEffects ();
		}
	}

	public void DisableEffects ()
	{
		// Disable the line renderer and the light.
		gunLine.enabled = false;
		gunLight.enabled = false;
	}

	void Shoot ()
	{
		// Reset the timer.
		timer = 0f;
		
		// Enable the light.
		gunLight.enabled = true;
		
		// Stop the particles from playing if they were, then start the particles.
		gunParticles.Stop ();
		gunParticles.Play ();
		
		// Enable the line renderer and set it's first position to be the end of the gun.
		gunLine.enabled = true;
		gunLine.SetPosition (0, init);
		
		// Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
		//shootRay.origin = pos;
		//shootRay.direction = Vector2.up;
		shootRay.origin = init;
		shootRay.direction = aimed;
		// Perform the raycast against gameobjects on the shootable layer and if it hits something...
		if(Physics2D.Raycast (shootRay.origin,shootRay.direction))
		{
			// Try and find an EnemyHealth script on the gameobject hit.
			//EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
			
			// If the EnemyHealth component exist...
			//if(enemyHealth != null)
			//{
				// ... the enemy should take damage.
				//enemyHealth.TakeDamage (damagePerShot, shootHit.point);
			//}
			
			// Set the second position of the line renderer to the point the raycast hit.
			gunLine.SetPosition (1, shootHit.point);
			//gunLine.setpo
		}
		// If the raycast didn't hit anything on the shootable layer...
		else
		{
			// ... set the second position of the line renderer to the fullest extent of the gun's range.
			//gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
			gunLine.SetPosition(1,new Vector3(shootRay.origin.x + shootRay.direction.x * range,
			                                  shootRay.origin.y + shootRay.direction.y * range ,-5));
		}
	}
}

