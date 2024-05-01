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
    public int noRoom;
    public int moveTo;
    //public Transform imageParents;
    public int overObject;
    public playerMove player;
    // private RectTransform rectTransform;
    public void OnBeginDrag(PointerEventData eventData){
        if(image.sprite != null){
            parentAfterDrag = transform.parent;
            preDropParentSlot = transform.parent.gameObject.GetComponent<InvSlot>().InvSlotNum;
            parentBeforeDrag = transform.parent;
            transform.SetParent(transform.root);
            transform.SetAsLastSibling();
            //Debug.Log("Begin drag");
            image.raycastTarget = false;
            // Vector3 newPosition = transform.position;
            // newPosition.z = 0;
            // transform.position = newPosition;
        }
    }

    public void OnDrag(PointerEventData eventData){
        if(image.sprite != null){
            transform.position = Input.mousePosition;
            // Vector3 newPosition = transform.position;
            // newPosition.z = 0;
            // transform.position = newPosition;
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
    void Start(){
        // rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Vector3 zeroPosition = new Vector3(rectTransform.position.x, rectTransform.position.y, 0);
        // rectTransform.position = zeroPosition;
        // Check if the right mouse button is clicked
        if (Input.GetMouseButtonDown(1) && overObject == 1)
        {
            if(image.sprite != null){
                int invSlot = transform.parent.GetComponent<InvSlot>().InvSlotNum;


                if(invSlot > 5){
                    noRoom = 1;
                    for (int i = 0; i < carsParents.GetChild(0).childCount; i++){
                        if(carsParents.GetChild(0).GetChild(i).childCount == 0){
                            noRoom = 0;
                            moveTo = i;
                            break;
                        }
                    }
                    if(noRoom == 0){
                        carsParents.GetChild(1).GetChild(invSlot - 6).GetChild(0).SetParent(carsParents.GetChild(0).GetChild(moveTo));
                    }
                }
                else{
                    noRoom = 1;
                    for (int i = 0; i < carsParents.GetChild(1).childCount; i++){
                        if(carsParents.GetChild(1).GetChild(i).childCount == 0){
                            noRoom = 0;
                            moveTo = i;
                            break;
                        }
                    }
                    if(noRoom == 0){
                        carsParents.GetChild(0).GetChild(invSlot - 1).GetChild(0).SetParent(carsParents.GetChild(1).GetChild(moveTo));
                    }
                }
                player.SetGarageInterface();
            }
        }
    }

    
}
