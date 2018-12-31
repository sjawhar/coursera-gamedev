using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour
{
	public int coinValue = 1;
	public bool isVictory = false;
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
		if (!controller || !controller.playerCanMove)
		{
			return;
		}

		taken = true;
		if (coinValue > 0)
		{
			controller.CollectCoin(coinValue);
		}

		if (isVictory)
		{
			controller.Victory();
		}

		if (explosion)
		{
			Instantiate(explosion,transform.position,transform.rotation);
		}

		Destroy(this.gameObject);
	}

}
