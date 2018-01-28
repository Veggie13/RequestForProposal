using UnityEngine;
using UnityEngine.Networking;

public class Messenger : MonoBehaviour {
    NetworkClient _client = new NetworkClient();
    public NetworkClient Client { get { return _client; } }

    public void Connect()
    {
        _client.Connect("127.0.0.1", 13584);
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
