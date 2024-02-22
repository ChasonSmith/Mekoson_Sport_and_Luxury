using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public int preDropParentSlot;
    public Image image;
    public Transform parentAfterDrag;
    public Transform parentBeforeDrag;
    public void OnBeginDrag(PointerEventData eventData){
        parentAfterDrag = transform.parent;
        preDropParentSlot = transform.parent.gameObject.GetComponent<InvSlot>().InvSlotNum;
        parentBeforeDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        //Debug.Log("Begin drag");
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData){
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("End drag");
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }
}
