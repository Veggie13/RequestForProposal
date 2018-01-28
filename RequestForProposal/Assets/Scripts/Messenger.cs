using UnityEngine;
using UnityEngine.Networking;

public class Messenger : MonoBehaviour {
    NetworkClient _client;
    public NetworkClient Client { get { return _client; } }

	// Use this for initialization
	void Start () {
        NetworkServer.Listen(13584);

        _client = new NetworkClient();
        _client.Connect("127.0.0.1", 13584);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
