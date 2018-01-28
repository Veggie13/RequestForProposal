using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CustomNetworkManager : NetworkManager {


    public override void OnServerConnect(NetworkConnection conn)
    {
        Debug.Log("OVERRIDE THE NETWORK MANAGER!");
        base.OnServerConnect(conn);
    }

    public override void OnClientSceneChanged(NetworkConnection conn)
    {
        Debug.Log("Scene Chnaged for CLient");
        base.OnClientSceneChanged(conn);
    }

}
