using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkManagerProxy : MonoBehaviour {

    public CustomNetworkManager NetworkManager { get; private set; }

	// Use this for initialization
	void Start () {
        this.NetworkManager = GameObject.Find("NetworkManagerPrime").GetComponent<CustomNetworkManager>();
	}
}
