using UnityEngine;

public class PlayerManager : MonoBehaviour {

    public int PlayerCount;
    public int LoveInterestPlayerID;

    [SerializeField]
    private GameObject SuitorBoardTemplate;
    [SerializeField]
    private GameObject LoveInterestBoard;

	// Use this for initialization
	void Start () {
		for (int i = 1; i <= PlayerCount; i++)
        {
            if (i == LoveInterestPlayerID)
            {
                continue;
            }
            var suitorGO = Instantiate(SuitorBoardTemplate, new Vector3(), Quaternion.identity);
            suitorGO.transform.position = new Vector3(100 * i, 0, 0);
            suitorGO.GetComponentInChildren<WordManagerProxy>().Connect();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
