using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LobbyUI2 : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(Spawn);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {
        GameObject.Find("NetworkManagerPrime").GetComponent<HostScript>().SpawnPlayer();
    }

}
