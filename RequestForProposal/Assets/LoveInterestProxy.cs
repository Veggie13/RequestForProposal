using UnityEngine;
using UnityEngine.Networking;

public class LoveInterestProxy : MonoBehaviour
{
    NetworkClient _client;

    private void Update()
    {
        if (_client == null)
        {
            _client = GameObject.Find("MessageManager").GetComponent<Messenger>().Client;
            _client.RegisterHandler(LoveInterestSentenceMessage.Type, nm => { SentenceSent(nm.ReadMessage<LoveInterestSentenceMessage>()); });
        }
    }

    public delegate void LoveInterestSentenceHandler(LoveInterestSentenceMessage msg);
    public event LoveInterestSentenceHandler SentenceSent = msg => { };
}
