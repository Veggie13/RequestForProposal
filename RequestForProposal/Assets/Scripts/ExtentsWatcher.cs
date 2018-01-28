using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtentsWatcher : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        GameObjectExited(collision.gameObject);
    }

    public delegate void GameObjectEvent(GameObject go);
    public event GameObjectEvent GameObjectExited = go => { };
}
