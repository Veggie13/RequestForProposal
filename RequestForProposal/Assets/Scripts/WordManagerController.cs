using UnityEngine;
using UnityEngine.Networking;

public class WordGeneratedMessage : MessageBase
{
    public static readonly short Type = MsgType.Highest + 2;
    public string Word;
}

public class WordTossedMessage : MessageBase
{
    public static readonly short Type = MsgType.Highest + 3;
    public string Word;
}

public class WordManagerController : MonoBehaviour
{
    void Start()
    {
        NetworkServer.RegisterHandler(WordTossedMessage.Type, nm => { TossWord(nm.ReadMessage<WordTossedMessage>().Word); });
        InvokeRepeating("GenerateRandomWord", 2f, 2f);
    }

    private void Update()
    {

    }

    void GenerateRandomWord()
    {
        GenerateWord("blah");
    }

    public void GenerateWord(string word)
    {
        var rand = new System.Random();
        int target = rand.Next(1, NetworkServer.connections.Count);
        var targetConnection = NetworkServer.connections[target];
        if (targetConnection != null)
        {
            NetworkServer.SendToClient(targetConnection.connectionId, WordGeneratedMessage.Type, new WordGeneratedMessage()
            {
                Word = word
            });
        }
        else
        {
            Debug.Log(string.Format("Why? {0}", target));
        }
    }

    public void TossWord(string word)
    {
        GenerateWord(word);
    }
}
