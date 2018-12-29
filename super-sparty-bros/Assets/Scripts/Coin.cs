using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

	public int coinValue = 1;
	public GameObject explosion;

	bool taken = false;

	// if the player touches the coin, it has not already been taken, and the player can move (not dead or victory)
	// then take the coin
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
		controller.CollectCoin(coinValue);

		// if explosion prefab is provide, then instantiate it
		if (explosion)
		{
			Instantiate(explosion,transform.position,transform.rotation);
		}
		// destroy the coin
		Destroy(this.gameObject);
	}

}
