using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestMessage : MessageBase
{
    public static readonly short Type = MsgType.Highest + 1;
    public string TestString;
    public int TestInt;
}

public class Messenger : MonoBehaviour {
    NetworkClient _client;

	// Use this for initialization
	void Start () {
        NetworkServer.Listen(13584);
        NetworkServer.RegisterHandler(TestMessage.Type, nm => { TestResponse(nm.ReadMessage<TestMessage>()); });

        _client = new NetworkClient();
        _client.RegisterHandler(TestMessage.Type, nm => { Tested(nm.ReadMessage<TestMessage>()); });
        _client.Connect("127.0.0.1", 13584);

        Tested += msg =>
        {
            Debug.Log(string.Format("{0} {1}!", msg.TestString, msg.TestInt));
            _client.Send(TestMessage.Type, msg);
        };
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void Test(TestMessage msg)
    {
        NetworkServer.SendToAll(TestMessage.Type, msg);
    }

    public static void TestResponse(TestMessage msg)
    {
        Debug.Log(string.Format("{0} {1}!", msg.TestString, msg.TestInt));
    }

    public delegate void TestHandler(TestMessage msg);
    public event TestHandler Tested;
}
