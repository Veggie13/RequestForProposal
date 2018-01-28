using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGameFromLobby : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(StartGame);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartGame()
    {
        GameObject.Find("NetworkManagerPrime").GetComponent<HostScript>().StartGame();
    }
}
