using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyButton : MonoBehaviour {
    WordManagerProxy _wordMgr;
    LoveInterestController _loveCtrl;
	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Button>().onClick.AddListener(OnClick);
        _wordMgr = GameObject.Find("WordManager").GetComponent<WordManagerProxy>();
        _loveCtrl = GameObject.Find("LoveInterest").GetComponent<LoveInterestController>();
        GameObject.Find("LoveInterest").GetComponent<LoveInterestProxy>().SentenceSent += msg =>
        {
            Debug.Log("Sentence: " + msg.Sentence);
        };
        _wordMgr.WordGenerated += msg =>
        {
            Debug.Log("Word: " + msg);
        };
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnClick()
    {
        _loveCtrl.SendSentence("tee hee hee");
        _wordMgr.TossWord("nononononono");
    }
}
