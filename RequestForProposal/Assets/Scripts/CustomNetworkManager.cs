using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Networking.NetworkSystem;

public class CustomNetworkManager : NetworkManager {

    public int curPlayer;

    public override void OnClientConnect(NetworkConnection conn)
    {
        // Create message to set the player
        IntegerMessage msg = new IntegerMessage(curPlayer);

        // Call Add player and pass the message
        ClientScene.AddPlayer(conn, 0, msg);

        Debug.Log("Client joined the Game");
    }


    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("Someone Connected to the Server!");
        base.OnServerConnect(conn);


    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {

        Debug.Log("Scene Changed for Client");
        base.OnClientSceneChanged(conn);
        GameObject.Find("NetworkManagerPrime").GetComponent<HostScript>().SpawnPlayer();
    }


}
