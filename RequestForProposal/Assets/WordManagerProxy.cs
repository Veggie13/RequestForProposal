using UnityEngine;
using UnityEngine.Networking;

public class WordManagerProxy : MonoBehaviour
{
    NetworkClient _client;

    void Start()
    {
    }

    void Update()
    {
        if (_client == null)
        {
            _client = GameObject.Find("MessageManager").GetComponent<Messenger>().Client;
            _client.RegisterHandler(WordGeneratedMessage.Type, nm => { WordGenerated(nm.ReadMessage<WordGeneratedMessage>()); });
        }
    }

    public delegate void WordGeneratedHandler(WordGeneratedMessage msg);
    public event WordGeneratedHandler WordGenerated = msg => { };

    public void TossWord(string word)
    {
        _client.Send(WordTossedMessage.Type, new WordTossedMessage()
        {
            Word = word
        });
    }
}
