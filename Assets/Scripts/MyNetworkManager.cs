using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class MyNetworkManager : NetworkManager 
{

	public override void OnServerConnect(NetworkConnection connection)
	{
		Debug.Log ("OnPlayerConnected");
	}

	/*public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId, NetworkReader extraMessageReader)
	{
		Debug.Log('on server add player');
		OnServerAddPlayer(conn, playerControllerId, extraMessageReader);
	}*/

	public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
	{
		Debug.Log ("Adding a player to game");
		var startingLocation = GetStartPosition ();
		var player = (GameObject)GameObject.Instantiate(playerPrefab, startingLocation.position, Quaternion.identity);
		NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
	}
}
