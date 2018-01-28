﻿using UnityEngine;
using UnityEngine.Networking;

public class WordManagerProxy : NetworkBehaviour
{
    [SerializeField]
    private GameObject WordManagerControllerGO;
    private WordManagerController _controller;

    void Start()
    {
    }

    public void Connect()
    {
        if (!isServer) return;
        _controller = WordManagerControllerGO.GetComponent<WordManagerController>();
        _controller.Connect(this);
    }

    public void GenerateWord(string word)
    {
        WordGenerated(word);
    }

    public delegate void WordGeneratedHandler(string word);
    public event WordGeneratedHandler WordGenerated = msg => { };

    public void TossWord(string word)
    {
        _controller.TossWord(word);
    }
}
