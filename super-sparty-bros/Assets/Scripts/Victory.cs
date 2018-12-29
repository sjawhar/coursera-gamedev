using UnityEngine;
using System.Collections;

public class Victory : MonoBehaviour {

	public GameObject explosion;

	bool taken = false;

	// if the player touches the victory object, it has not already been taken, and the player can move (not dead or victory)
	// then the player has reached the victory point of the level
	void OnTriggerEnter2D (Collider2D other)
	{
		if (taken || other.tag != "Player")
		{
			return;
		}
		CharacterController2D controller = other.gameObject.GetComponent<CharacterController2D>();
		if (!controller || !controller.playerCanMove) {
			return;
		}
		
		taken = true;
		controller.Victory();

		if (explosion)
		{
			Instantiate(explosion,transform.position,transform.rotation);
		}

		Destroy(this.gameObject);
	}

}
