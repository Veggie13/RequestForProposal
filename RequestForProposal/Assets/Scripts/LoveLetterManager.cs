﻿using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoveLetterManager : MonoBehaviour {

    [SerializeField]
    private Transform background;
    [SerializeField]
    private Text letterText;

    static string BLANK_MARKER = "%B";
    public static string BLANK = "__________";

    private List<Sentence> sentences = new List<Sentence>();
    private Sentence selectedSentence;
    private int lastIndexToAvoidRepeats = 0;

    private void Start()
    {
        sentences.Add(new Sentence("You make my heart %B.", WordType.VERB));
        sentences.Add(new Sentence("I want to %B with you in the rain.", WordType.VERB));
        sentences.Add(new Sentence("I love the way you %B with joy.", WordType.VERB));
        sentences.Add(new Sentence("I am happiest when we %B together.", WordType.VERB));
        sentences.Add(new Sentence("When you %B, I'm in heaven.", WordType.VERB));
        sentences.Add(new Sentence("It's magical the way you %B.", WordType.VERB));

        sentences.Add(new Sentence("Your %B alone could inspire a sonnet.", WordType.NOUN));
        sentences.Add(new Sentence("I see your %B when I close my eyes.", WordType.NOUN));
        sentences.Add(new Sentence("Your %B haunts my dreams at night.", WordType.NOUN));
        sentences.Add(new Sentence("You have the most beautiful %B I've ever seen.", WordType.NOUN));
        sentences.Add(new Sentence("Your %B is one of your loveliest features.", WordType.NOUN));
        sentences.Add(new Sentence("Wars would be fought over your %B.", WordType.NOUN));
        sentences.Add(new Sentence("You move like a %B.", WordType.NOUN));
        sentences.Add(new Sentence("You are as gentle as a %B.",  WordType.NOUN));
        sentences.Add(new Sentence("You remind me of a %B.", WordType.NOUN));
        sentences.Add(new Sentence("Your %B keeps me awake at night.", WordType.NOUN));

        sentences.Add(new Sentence("Your voice is as %B as a summer day.", WordType.ADJECTIVE));
        sentences.Add(new Sentence("My heart flutters at the thought of your %B eyes.", WordType.ADJECTIVE));

        CreateNewLetterSentence();
        /*  sentences.Add(new Sentence("You fill my heart with a AA song."));
          sentences.Add(new Sentence("I think we go together like NN and NN."));
          sentences.Add(new Sentence("Your beauty makes my NN VV."));
          sentences.Add(new Sentence("I would VV if I never saw your NN again!"));
          sentences.Add(new Sentence("Oh how your NN VVs in the sunlight!"));
          sentences.Add(new Sentence("Together, we will make AA NN!"));
          sentences.Add(new Sentence("I would love to VV your AA NN forever."));
          sentences.Add(new Sentence("I am amazed how you AV VV your NN."));
          sentences.Add(new Sentence("You never cease to AV VV my NN!"));
          sentences.Add(new Sentence("To conclude, you AV VV my NN."));
          sentences.Add(new Sentence("I will forever long to AV VV your NN."));
          sentences.Add(new Sentence("Your NN and my NN will make AA NN together.")) */
        ;
    }

    public void CreateNewLetterSentence()
    {
        selectedSentence = getRandomSentence();
        letterText.text = selectedSentence.getSentence(BLANK);
    }

    public Sentence PickThisSentence()
    {
        return selectedSentence;
    }

    private Sentence getRandomSentence()
    {
        int rand = Random.Range(0, sentences.Count - 1);
        if (rand == lastIndexToAvoidRepeats)
        {
            rand++;
        }
        Sentence randomSentence = sentences[rand];
        lastIndexToAvoidRepeats = rand;
        return randomSentence;
    }

    public enum WordType
    {
        NOUN, VERB, ADJECTIVE, ADVERB
    }

    public class Sentence
    {
        private string sentence;
        private WordType[] blanks;

        public Sentence(string sentence, params WordType[] blanks)
        {
            this.sentence = sentence;
            this.blanks = blanks;
        }

        public string getSentence(string replaceBlankWith)
        {
            return sentence.Replace(BLANK_MARKER, replaceBlankWith);
        }

        public WordType getWordType()
        {
            return blanks[0];
        }
    }
}
