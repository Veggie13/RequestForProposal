using UnityEngine;
using UnityEngine.Networking;

public class PlayerManager : NetworkBehaviour {
    [SyncVar]
    public int PlayerCount;
    [SyncVar]
    public int LoveInterestPlayerID;

    private int PlayerID;

    [SerializeField]
    private GameObject SuitorBoardTemplate;
    [SerializeField]
    private GameObject LoveInterestBoard;
    [SerializeField]
    private GameObject NetworkManagerGO;

	// Use this for initialization
	void Start () {
        var networkMgr = NetworkManagerGO.GetComponent<NetworkManagerProxy>().NetworkManager;
        if (!isServer)
        {
            PlayerID = networkMgr.LocalID;
            //var playerGO = GameObject.Find("player" + PlayerID.ToString());
            //var playerCamera = playerGO.GetComponentInChildren<Camera>();
            //gameObject.GetComponentInChildren<Camera>().enabled = false;
            //playerCamera.enabled = true;
            return;
        }

        PlayerCount = networkMgr.Players.Count;
        if (PlayerCount == 0) return;
        LoveInterestPlayerID = networkMgr.Players[0];

        for (int i = 1; i <= PlayerCount; i++)
        {
            //if (i == LoveInterestPlayerID)
            //{
            //    LoveInterestBoard.name = "player" + i.ToString();
            //    continue;
            //}
            //var suitorGO = Instantiate(SuitorBoardTemplate, new Vector3(), Quaternion.identity);
            //suitorGO.transform.position = new Vector3(100 * (i + 1), 0, 0);
            //suitorGO.name = "player" + i.ToString();
            var suitorGO = GameObject.Find("player" + i.ToString());
            suitorGO.GetComponentInChildren<WordManagerProxy>().Connect();
            //NetworkServer.Spawn(suitorGO);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
