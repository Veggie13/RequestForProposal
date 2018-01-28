using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Word : NetworkBehaviour {

    [SerializeField]
    private int ID;

    public string WordText;

    [SyncVar]
    public string Name;

	// Use this for initialization
	void Start () {
        if (!isServer)
        {
            var suitor = GameObject.Find(Name);
            var canvas = suitor.GetComponentInChildren<Canvas>();
            var wordRect = gameObject.GetComponent<RectTransform>();
            wordRect.SetParent(canvas.transform);
        }
        //ID = new System.Random().Next(int.MaxValue);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
