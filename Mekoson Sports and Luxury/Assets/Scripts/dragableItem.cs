using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class dragableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    public int preDropParentSlot;
    public Image image;
    public Transform parentAfterDrag;
    public Transform parentBeforeDrag;
    public Transform carsParents;
    //public Transform imageParents;
    public int overObject;
    public playerMove player;
    public void OnBeginDrag(PointerEventData eventData){
        if(image.sprite != null){
            parentAfterDrag = transform.parent;
            preDropParentSlot = transform.parent.gameObject.GetComponent<InvSlot>().InvSlotNum;
            parentBeforeDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            //Debug.Log("Begin drag");
            image.raycastTarget = false;
        }
    }

    public void OnDrag(PointerEventData eventData){
        if(image.sprite != null){
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData){
        //Debug.Log("End drag");
        if(image.sprite != null){
            transform.SetParent(parentAfterDrag);
            image.raycastTarget = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        overObject = 1;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        overObject = 0;
    }

    void Update()
    {
        // Check if the right mouse button is clicked
        if (Input.GetMouseButtonDown(1) && overObject == 1)
        {
            if(image.sprite != null){
                int invSlot = transform.parent.GetComponent<InvSlot>().InvSlotNum;
                if(invSlot > 5){
                    if(carsParents.GetChild(0).childCount < 5){
                        carsParents.GetChild(1).GetChild(invSlot - 6).SetParent(carsParents.GetChild(0));
                        // int whereNew = carsParents.GetChild(0).childCount - 1;
                        // GameObject otherImage = transform.parent.parent.GetChild(whereNew).GetChild(0).gameObject;
                        // parentBeforDrag = transfrom.parent;
                        // transform.SetParent(otherImage.transform.parent);
                        // otherImage.SetParent(parentBeforeDrag);
                        // parentBeforeDrag(transform.parent);
                        // trasnform.position = transform.parent.position;
                        // otherImage.transform.position = otherImage.transform,parent.position;
                    }
                }
                else{
                    if(carsParents.GetChild(1).childCount < 25){
                        carsParents.GetChild(0).GetChild(invSlot - 1).SetParent(carsParents.GetChild(1));
                        // int whereNew = carsParents.GetChild(1).childCount - 1 + 5;
                        // GameObject otherImage = transform.parent.parent.GetChild(whereNew).GetChild(0).gameObject;
                        // parentBeforDrag = transfrom.parent;
                        // transform.SetParent(otherImage.transform.parent);
                        // otherImage.SetParent(parentBeforeDrag);
                        // parentBeforeDrag(transform.parent);
                        // trasnform.position = transform.parent.position;
                        // otherImage.transform.position = otherImage.transform,parent.position;
                    }
                }
                player.SetGarageInterface();
            }
        }
    }

    
}
