using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkServerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        NetworkServer.Listen(13584);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
