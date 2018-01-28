using UnityEngine;
using UnityEngine.Networking;

public class WordManagerProxy : MonoBehaviour
{
    NetworkClient _client;

    [SerializeField]
    private GameObject MessageManagerGO;

    void Start()
    {
        _client = MessageManagerGO.GetComponent<Messenger>().Client;
        _client.RegisterHandler(WordGeneratedMessage.Type, nm => { WordGenerated(nm.ReadMessage<WordGeneratedMessage>().Word); });
    }

    public delegate void WordGeneratedHandler(string word);
    public event WordGeneratedHandler WordGenerated = msg => { };

    public void TossWord(string word)
    {
        _client.Send(WordTossedMessage.Type, new WordTossedMessage()
        {
            Word = word
        });
    }
}
