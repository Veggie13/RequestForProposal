using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI : MonoBehaviour {

    // Use this for initialization
    void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(GoBack);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Spawn()
    {
        GameObject.Find("NetworkManagerPrime").GetComponent<HostScript>().SpawnPlayer();
    }

    void GoBack (){
        GameObject.Find("NetworkManagerPrime").GetComponent<HostScript>().StopServer();
    }
}
