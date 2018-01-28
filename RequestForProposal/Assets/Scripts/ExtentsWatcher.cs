using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ExtentsWatcher : NetworkBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!isServer) return;
        GameObjectExited(collision.gameObject);
    }

    public delegate void GameObjectEvent(GameObject go);
    public event GameObjectEvent GameObjectExited = go => { };
}
