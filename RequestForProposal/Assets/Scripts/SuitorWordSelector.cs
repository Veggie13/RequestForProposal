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
    private List<string> adjectives = new List<string>();
    private int lastIndexToAvoidRepeats = 0;

    void Start()
    {
        currentSentence = new LoveLetterManager.Sentence("Waiting for adlib...", LoveLetterManager.WordType.NONE);
        currentWord = new Word("", LoveLetterManager.WordType.NONE);
        renderW();

        nouns.Add("heart");
        nouns.Add("love");
        nouns.Add("dream");
        nouns.Add("banana");
        nouns.Add("soul");
        nouns.Add("career");
        nouns.Add("body");
        nouns.Add("mind");
        nouns.Add("toe");
        nouns.Add("hand");
        nouns.Add("elbow");
        nouns.Add("belly button");
        nouns.Add("forehead");
        nouns.Add("spirit");
        nouns.Add("allowance");
        nouns.Add("wallet");
        nouns.Add("bank account");
        nouns.Add("job");
        nouns.Add("poetry");
        nouns.Add("art");
        nouns.Add("dog");
        nouns.Add("cat");
        nouns.Add("goldfish");
        nouns.Add("hair");
        nouns.Add("ear");
        nouns.Add("peach");
        //nouns.Add("");

        verbs.Add("sing");
        verbs.Add("cook");
        verbs.Add("clean");
        verbs.Add("sigh");
        verbs.Add("dream");
        verbs.Add("dance");
        verbs.Add("cry");
        verbs.Add("swim");
        verbs.Add("defuse a bomb");
        verbs.Add("twirl around");
        verbs.Add("eat");
        verbs.Add("eat gummy bears");
        verbs.Add("abandon my children");
        verbs.Add("drive");
        verbs.Add("write poetry");
        //verbs.Add("");

        adjectives.Add("beautiful");
        adjectives.Add("stinky");
        adjectives.Add("clean");
        adjectives.Add("appalling");
        adjectives.Add("crusty");
        adjectives.Add("sweet");
        adjectives.Add("nice");
        adjectives.Add("decent");
        adjectives.Add("frustrating");
        adjectives.Add("picky");
        adjectives.Add("tart");
        adjectives.Add("nasty");
        adjectives.Add("irrelevant");
        adjectives.Add("smoking");
        adjectives.Add("hot");
        adjectives.Add("cranky");
        adjectives.Add("helpful");
        adjectives.Add("spotty");
        adjectives.Add("shimmering");
        adjectives.Add("sparkly");
        adjectives.Add("soft");
        adjectives.Add("hard");
        adjectives.Add("bendy");
        adjectives.Add("questionable");
        //adjectives.Add("");
    }

    public void SetSentence()
    {
        this.currentSentence = loveLetterSource.PickThisSentence();
        sentenceDisplay.text = currentSentence.getSentence(LoveLetterManager.BLANK);
    }

    public void GetNewWord()
    {
        LoveLetterManager.WordType wordType = currentSentence.getWordType();
        currentWord = new Word(getRandomWord(wordType), wordType);
        renderW();
    }

    public void ChooseThisWord()
    {
        Debug.Log("CHOOSE WORD: " + currentWord);
    }

    private void renderW()
    {
        sentenceDisplay.text = currentSentence.getSentence(currentWord.getWord().ToUpper());
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
                words = adjectives;
                break;
        }

        int rand = Random.Range(0, words.Count - 1);
        if (rand == lastIndexToAvoidRepeats)
        {
            rand++;
        }
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
