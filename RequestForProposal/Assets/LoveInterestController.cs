using UnityEngine;
using UnityEngine.Networking;

public class LoveInterestSentenceMessage : MessageBase
{
    public static readonly short Type = MsgType.Highest + 1;
    public string Sentence;
}

public class LoveInterestController : MonoBehaviour
{
    void Start()
    {
    }

    private void Update()
    {
        
    }

    public void SendSentence(string sentence)
    {
        NetworkServer.SendToAll(LoveInterestSentenceMessage.Type, new LoveInterestSentenceMessage()
        {
            Sentence = sentence
        });
    }
}
