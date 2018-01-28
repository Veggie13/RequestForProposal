using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtentsWatcher : MonoBehaviour {

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("GONE!");
        Destroy(collision.gameObject);
    }
}
