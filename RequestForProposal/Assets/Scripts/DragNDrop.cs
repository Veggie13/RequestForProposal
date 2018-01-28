using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

[RequireComponent(typeof(Image))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class DragNDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public delegate void DragEvent(DragNDrop item);
    static public event DragEvent OnItemDragStartEvent;                             // Drag start event
    static public event DragEvent OnItemDragEndEvent;                               // Drag end event
    bool isBeingDragged = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        isBeingDragged = true;
        Canvas canvas = GetComponentInParent<Canvas>();                             // Get parent canvas
        if (OnItemDragStartEvent != null)
        {
            OnItemDragStartEvent(this);                                             // Notify all about item drag start
        }
    }

    public void OnDrag(PointerEventData data)
    {
        this.transform.position = Input.mousePosition;                          // Item's icon follows to cursor
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isBeingDragged = false;
        MakeVisible(true);                                                          // Make item visible in cell
        if (OnItemDragEndEvent != null)
        {
            OnItemDragEndEvent(this);                                               // Notify all cells about item drag end
        }
        //        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //        this.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.isBeingDragged)
        {
            Debug.Log("HIT!");
            Rigidbody2D thisThing = collision.rigidbody;
            Rigidbody2D theOtherThing = collision.otherRigidbody;
            theOtherThing.GetComponent<DragNDrop>().isBeingDragged = false;
            float xOffset = thisThing.position.x - theOtherThing.position.x;
            float yOffset = thisThing.position.y - theOtherThing.position.y;
            float force = 750;
            theOtherThing.AddForce(new Vector2(force * xOffset, force * yOffset));
        }

    }

    public void MakeRaycast(bool condition)
    {
        Image image = GetComponent<Image>();
        if (image != null)
        {
            image.raycastTarget = condition;
        }
    }

    public void MakeVisible(bool condition)
    {
        GetComponent<Image>().enabled = condition;
    }

}
