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
        if (NetworkServer.connections.Count == 0)
            return;
        var rand = new System.Random();
        NetworkConnection targetConnection = null;
        for (int i = 0; i < 10 && targetConnection == null; i++)
        {
            int target = rand.Next(0, NetworkServer.connections.Count);
            targetConnection = NetworkServer.connections[target];
        }
        if (targetConnection != null)
        {
            NetworkServer.SendToClient(targetConnection.connectionId, WordGeneratedMessage.Type, new WordGeneratedMessage()
            {
                Word = word
            });
        }
    }

    public void TossWord(string word)
    {
        GenerateWord(word);
    }
}
