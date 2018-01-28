﻿
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Networking;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class DragNDrop : NetworkBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField]
    private GameObject CanvasGO;

    private static float MAX_TIME = 0.6f;

    public delegate void DragEvent(DragNDrop item);
    [SyncVar] bool isBeingDragged = false;
    [SyncVar] float xPositionStart;
    [SyncVar] float yPositionStart;
    //Time time;
    [SyncVar] float timeTracker = MAX_TIME;

    [SyncVar] private int numberTimes = 0;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isServer) return;
        isBeingDragged = true;
        ResetStartConditions();

        getRB().velocity = new Vector2(0, 0);
        getRB().angularVelocity = 0;
    }

    public void OnDrag(PointerEventData data)
    {
        if (isServer) return;
        var canvasRect = CanvasGO.GetComponent<RectTransform>();
        this.transform.localPosition = Input.mousePosition - 0.5f * new Vector3(canvasRect.rect.width, canvasRect.rect.height, 0);
        getRB().velocity = new Vector2();
        getRB().angularVelocity = 0f;
        isBeingDragged = true;
    }
    
    void Update()
    {
        if (!isServer) return;
        if (isBeingDragged)
        {
            timeTracker = timeTracker - Time.deltaTime;
            if (timeTracker < 0)
            {
                numberTimes++;
                ResetStartConditions();
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (isServer) return;
        if (isBeingDragged)
        {
            Rigidbody2D rb = getRB();
            float xDelta = rb.position.x - xPositionStart;
            float yDelta = rb.position.y - yPositionStart;
            rb.velocity = new Vector2(xDelta, yDelta);
            rb.angularVelocity = 0.05f * yDelta;
        }
        isBeingDragged = false;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isServer) return;
        if (this.isBeingDragged)
        {
            Rigidbody2D thisThing = collision.rigidbody;
            Rigidbody2D theOtherThing = collision.otherRigidbody;
            float xOffset = thisThing.position.x - theOtherThing.position.x;
            float yOffset = thisThing.position.y - theOtherThing.position.y;
            float force = 750;
            if (theOtherThing.gameObject != gameObject)
            {
                theOtherThing.AddForce(new Vector2(-force * xOffset, -force * yOffset));
            }
            else
            {
                thisThing.AddForce(new Vector2(force * xOffset, force * yOffset));
            }
        }
    }

    private void ResetStartConditions()
    {
        Rigidbody2D rb = getRB();
        xPositionStart = rb.position.x;
        yPositionStart = rb.position.y;
        timeTracker = MAX_TIME;
    }

    private Rigidbody2D getRB()
    {
        return this.GetComponent<Rigidbody2D>();
    }

}
