using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int PlayerCount;

    [SerializeField]
    private GameObject SuitorBoardTemplate;
    //private List<>

	// Use this for initialization
	void Start () {
		for (int i = 1; i <= PlayerCount; i++)
        {
            var suitorGO = Instantiate(SuitorBoardTemplate, new Vector3(), Quaternion.identity);
            suitorGO.transform.position = new Vector3(100 * i, 0, 0);
            suitorGO.GetComponentInChildren<Messenger>().Connect();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
