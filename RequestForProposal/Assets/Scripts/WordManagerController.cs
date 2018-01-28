using UnityEngine;
using System.Collections.Generic;

public class WordManagerController : MonoBehaviour
{
    private List<WordManagerProxy> _proxies = new List<WordManagerProxy>();

    void Start()
    {
        InvokeRepeating("GenerateRandomWord", 2f, 2f);
    }

    void GenerateRandomWord()
    {
        GenerateWord("blah");
    }

    public void Connect(WordManagerProxy proxy)
    {
        _proxies.Add(proxy);
    }

    public void GenerateWord(string word)
    {
        if (_proxies.Count == 0)
            return;
        var rand = new System.Random();
        int target = rand.Next(0, _proxies.Count);
        var proxy = _proxies[target];
        if (proxy != null)
        {
            proxy.GenerateWord(word);
        }
    }

    public void TossWord(string word)
    {
        GenerateWord(word);
    }
}
