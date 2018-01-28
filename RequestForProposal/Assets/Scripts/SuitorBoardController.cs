using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuitorBoardController : MonoBehaviour {

    [SerializeField]
    private GameObject ExtentsGO;
    [SerializeField]
    private GameObject WordManagerGO;
    [SerializeField]
    private GameObject WordTemplateGO;
    [SerializeField]
    private GameObject CanvasGO;

    private ExtentsWatcher ExtentsWatcher;
    private WordManagerProxy WordManager;

	// Use this for initialization
	void Start () {
        this.ExtentsWatcher = ExtentsGO.GetComponent<ExtentsWatcher>();
        this.ExtentsWatcher.GameObjectExited += ExtentsWatcher_GameObjectExited;

        this.WordManager = WordManagerGO.GetComponent<WordManagerProxy>();
        this.WordManager.WordGenerated += WordManager_WordGenerated;
	}

    private void WordManager_WordGenerated(string word)
    {
        GenerateWordGO(word);
    }

    private void ExtentsWatcher_GameObjectExited(GameObject go)
    {
        var word = go.GetComponent<Word>();
        if (word != null)
        {
            WordManager.TossWord(word.WordText);
            Destroy(go);
        }
    }

    void GenerateWordGO(string word)
    {
        float angle = Random.value * 2f * Mathf.PI;

        var wordGO = Instantiate(WordTemplateGO, new Vector3(), Quaternion.identity);
        var wordScript = wordGO.GetComponent<Word>();
        wordScript.WordText = word;
        wordGO.transform.SetParent(CanvasGO.transform);
        var canvasRect = CanvasGO.GetComponent<RectTransform>();
        var offset = 0.5f * canvasRect.rect.width * Mathf.Sqrt(2) * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        var startPos = 0.5f * new Vector3(canvasRect.rect.width, canvasRect.rect.height, 0) + offset;
        var startVel = -0.2f * offset + 0.01f * canvasRect.rect.width * new Vector3(Mathf.Cos(angle * angle), Mathf.Sin(angle * angle), 0);
        wordGO.transform.position = startPos;
        wordGO.GetComponent<Rigidbody2D>().velocity = startVel;
        wordGO.GetComponent<Rigidbody2D>().angularVelocity = angle * 10f;
    }
}
