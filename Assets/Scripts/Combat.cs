using UnityEngine;
using System.Collections;
using UnityEngine.Networking;


public class Combat : NetworkBehaviour {

	public const int maxHealth = 100;

	[SyncVar]
	public int health = maxHealth;

	public void TakeDamage(int amount)
	{
		health -= amount;
		if (health <= 0) {
			Debug.Log ("YOU DEAD!");
			RpcRespawn();
			health = maxHealth;
		}
	}

	[ClientRpc]
	void RpcRespawn()
	{
		if (isLocalPlayer) {
			// move back to zero location
			transform.position = Vector3.zero;
		}
	}
	
}
