using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuitorWordSelector : MonoBehaviour {

    [SerializeField]
    LoveLetterManager loveLetterSource;
    [SerializeField]
    Text sentenceDisplay;

    private Word currentWord;
    private LoveLetterManager.Sentence currentSentence;
    private List<string> nouns = new List<string>();
    private List<string> verbs = new List<string>();
    private List<Word> adjectives = new List<Word>();
    private List<Word> adverbs = new List<Word>();
    private int lastIndexToAvoidRepeats = 0;

    void Start()
    {
        currentSentence = new LoveLetterManager.Sentence("Waiting for adlib...", LoveLetterManager.WordType.ADVERB);
        currentWord = new Word("test", LoveLetterManager.WordType.NOUN);
        renderW();

        nouns.Add("heart");
        nouns.Add("love");
        nouns.Add("dream");
        nouns.Add("banana");
        nouns.Add("soul");

        verbs.Add("sing");
        verbs.Add("cook");
        verbs.Add("clean");
        verbs.Add("sigh");
        verbs.Add("dream");
    }

    public void SetSentence()
    {
        this.currentSentence = loveLetterSource.PickThisSentence();
        sentenceDisplay.text = currentSentence.getSentence(LoveLetterManager.BLANK);
    }

    public void GetNewWord()
    {
        LoveLetterManager.WordType wordType = currentSentence.getWordType();
        currentWord = new Word(getRandomWord(wordType), LoveLetterManager.WordType.ADVERB);
        renderW();
    }

    public void ChooseThisWord()
    {
        Debug.Log("CHOOSE WORD: " + currentWord);
    }

    private void renderW()
    {
        sentenceDisplay.text = currentSentence.getSentence(currentWord.getWord());
    }

    private string getRandomWord(LoveLetterManager.WordType type)
    {
        List<string> words = new List<string>();
        switch (type)
        {
            case LoveLetterManager.WordType.NOUN:
                words = nouns;
                break;
            case LoveLetterManager.WordType.VERB:
                words = verbs;
                break;
            case LoveLetterManager.WordType.ADJECTIVE:
//                words = adjectives;
                break;
            case LoveLetterManager.WordType.ADVERB:
//                words = adverbs;
                break;
        }

        int rand = Random.Range(0, words.Count - 1);
        if (rand == lastIndexToAvoidRepeats)
        {
            rand++;
        }
//        Word randomWord = words[rand];
        lastIndexToAvoidRepeats = rand;
        return words[rand];
    }

    public class Word
    {
        private LoveLetterManager.WordType type;
        private string thisWord;

        public Word(string word, LoveLetterManager.WordType type)
        {
            thisWord = word;
            this.type = type;
        }

        public string getWord()
        {
            return thisWord;
        }
    }
}
