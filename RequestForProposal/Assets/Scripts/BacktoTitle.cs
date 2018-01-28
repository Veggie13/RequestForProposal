using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BacktoTitle : MonoBehaviour {

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(GoBack);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GoBack (){
        GameObject.Find("NetworkManager").GetComponent<HostScript>().StopServer();
    }
}
