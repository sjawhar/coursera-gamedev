using UnityEngine;
using System.Collections;

public class TargetBehavior : MonoBehaviour
{

	// target impact on game
	public int scoreAmount = 0;
	public float timeAmount = 0.0f;

	// explosion when hit?
	public GameObject explosionPrefab;

	// when collided with another gameObject
	void OnCollisionEnter (Collision newCollision)
	{
		// exit if there is a game manager and the game is over
		if (GameManager.gm && GameManager.gm.gameIsOver)
		{
			return;
		}
		// only do stuff if hit by a projectile
		else if (newCollision.gameObject.tag != "Projectile")
		{
			return;
		}
		
		if (explosionPrefab)
		{
			Instantiate(explosionPrefab, transform.position, transform.rotation);
		}

		if (GameManager.gm)
		{
			GameManager.gm.targetHit(scoreAmount, timeAmount);
		}
			
		Destroy(newCollision.gameObject);
		Destroy(gameObject);
	}
}
