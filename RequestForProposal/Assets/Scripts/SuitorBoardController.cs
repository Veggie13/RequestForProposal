using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class SuitorBoardController : NetworkBehaviour {

    public GameObject WordManagerGO;

    [SerializeField]
    private GameObject ExtentsGO;
    [SerializeField]
    private GameObject WordTemplateGO;
    [SerializeField]
    private GameObject CanvasGO;

    private ExtentsWatcher ExtentsWatcher;
    private WordManagerProxy WordManager;

	// Use this for initialization
	void Start () {
        if (isLocalPlayer) return;

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
            NetworkServer.Destroy(go);
        }
    }

    void GenerateWordGO(string word)
    {
        float angle = Random.value * 2f * Mathf.PI;

        var canvasRect = CanvasGO.GetComponent<RectTransform>();
        float worldHalfWidth = CanvasGO.transform.TransformPoint(canvasRect.rect.width / 2, 0, 0).x - CanvasGO.transform.position.x;
        var offset = 0.5f * canvasRect.rect.width * Mathf.Sqrt(2) * new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
        var wordGO = Instantiate(WordTemplateGO, new Vector3(), Quaternion.identity, CanvasGO.transform);
        wordGO.GetComponent<RectTransform>().localPosition = offset;
        wordGO.tag = "Untagged";
        var wordScript = wordGO.GetComponent<Word>();
        wordScript.WordText = word;
        wordScript.Name = gameObject.name;
        var startVel = -0.3f * worldHalfWidth * new Vector3(Mathf.Cos(angle) - 0.1f * Mathf.Cos(angle * angle), Mathf.Sin(angle) - 0.1f * Mathf.Sin(angle * angle), 0);
        wordGO.GetComponent<Rigidbody2D>().velocity = startVel;
        wordGO.GetComponent<Rigidbody2D>().angularVelocity = angle * 10f;
        NetworkServer.Spawn(wordGO);
    }
}
