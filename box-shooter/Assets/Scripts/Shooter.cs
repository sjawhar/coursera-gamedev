using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
	public GameObject projectile;
	public float power = 10.0f;
	
	public AudioClip shootSFX;
	
	void Update ()
	{
		if (!(projectile && (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))))
		{	
			return;
		}
		GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation) as GameObject;

		Rigidbody projectileRb = newProjectile.GetComponent<Rigidbody>();
		if (!projectileRb) 
		{
			projectileRb = newProjectile.AddComponent<Rigidbody>();
		}
		projectileRb.AddForce(transform.forward * power, ForceMode.VelocityChange);
		
		if (!shootSFX)
		{
			return;
		}
		AudioSource projectileAudioSource = newProjectile.GetComponent<AudioSource>();
		if (projectileAudioSource) {
			projectileAudioSource.PlayOneShot(shootSFX);
			return;
		}
		AudioSource.PlayClipAtPoint(shootSFX, newProjectile.transform.position);
	}
}
