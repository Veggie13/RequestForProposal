using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {

    public int LocalID;
    public List<int> Players = new List<int>();

    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("OVERRIDE THE NETWORK MANAGER!");
        Players.Add(conn.connectionId);
        base.OnServerConnect(conn);
    }

    public override void OnClientConnect(NetworkConnection conn)
    {
        LocalID = conn.connectionId;
        base.OnClientConnect(conn);
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        Debug.Log("Scene Chnaged for CLient");
        base.OnClientSceneChanged(conn);
    }

}
