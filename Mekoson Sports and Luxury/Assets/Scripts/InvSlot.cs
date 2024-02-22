using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvSlot : MonoBehaviour, IDropHandler
{
    public int InvSlotNum;
    public GameObject allCarsOwned;
    public int parentIndex1;
    public int parentIndex2;
    public void OnDrop(PointerEventData eventData){
    GameObject dropped = eventData.pointerDrag;
    if(dropped.GetComponent<dragableItem>().image.sprite != null){
        if(transform.childCount == 0){
            dropped = eventData.pointerDrag;
            dragableItem dragItem = dropped.GetComponent<dragableItem>();
            dragItem.parentAfterDrag = transform;
        }
        else{
            if(transform.GetChild(0).gameObject.GetComponent<dragableItem>().image.sprite != null){
            dropped = eventData.pointerDrag;
            dragableItem dragItem = dropped.GetComponent<dragableItem>();
            transform.GetChild(0).SetParent(dragItem.parentBeforeDrag);
            dragItem.parentAfterDrag = transform;
            parentIndex1 = dragItem.parentBeforeDrag.gameObject.GetComponent<InvSlot>().InvSlotNum;
            parentIndex2 = dragItem.parentAfterDrag.gameObject.GetComponent<InvSlot>().InvSlotNum;
            if(parentIndex1 != parentIndex2){
                if(parentIndex1 < 6){
                    if(parentIndex2 < 6){
                        if(parentIndex1 > parentIndex2){
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex1 - 1).SetSiblingIndex(parentIndex2 - 1);
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex2).SetSiblingIndex(parentIndex1 - 1);
                        }
                        else{
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex1 - 1).SetSiblingIndex(parentIndex2 - 1);
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex2 - 2).SetSiblingIndex(parentIndex1 - 1);
                        }

                    }
                    else{
                        if(parentIndex1 > 5){
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex1 - 6).SetParent(allCarsOwned.transform.GetChild(0));
                            allCarsOwned.transform.GetChild(0).GetChild(allCarsOwned.transform.GetChild(0).transform.childCount - 1).SetSiblingIndex(parentIndex2 - 1);
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex2).SetParent(allCarsOwned.transform.GetChild(1));
                            allCarsOwned.transform.GetChild(1).GetChild(allCarsOwned.transform.GetChild(1).transform.childCount - 1).SetSiblingIndex(parentIndex1 - 6);
                        }
                        else{
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex2 - 6).SetParent(allCarsOwned.transform.GetChild(0));
                            allCarsOwned.transform.GetChild(0).GetChild(allCarsOwned.transform.GetChild(0).transform.childCount - 1).SetSiblingIndex(parentIndex1 - 1);
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex1).SetParent(allCarsOwned.transform.GetChild(1));
                            allCarsOwned.transform.GetChild(1).GetChild(allCarsOwned.transform.GetChild(1).transform.childCount - 1).SetSiblingIndex(parentIndex2 - 6);
                        }
                    }
                }
                else{
                    if(parentIndex2 < 6){
                        if(parentIndex1 > 5){
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex1 - 6).SetParent(allCarsOwned.transform.GetChild(0));
                            allCarsOwned.transform.GetChild(0).GetChild(allCarsOwned.transform.GetChild(0).transform.childCount - 1).SetSiblingIndex(parentIndex2 - 1);
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex2).SetParent(allCarsOwned.transform.GetChild(1));
                            allCarsOwned.transform.GetChild(1).GetChild(allCarsOwned.transform.GetChild(1).transform.childCount - 1).SetSiblingIndex(parentIndex1 - 6);
                        }
                        else{
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex2 - 6).SetParent(allCarsOwned.transform.GetChild(0));
                            allCarsOwned.transform.GetChild(0).GetChild(allCarsOwned.transform.GetChild(0).transform.childCount - 1).SetSiblingIndex(parentIndex1 - 1);
                            allCarsOwned.transform.GetChild(0).GetChild(parentIndex1).SetParent(allCarsOwned.transform.GetChild(1));
                            allCarsOwned.transform.GetChild(1).GetChild(allCarsOwned.transform.GetChild(1).transform.childCount - 1).SetSiblingIndex(parentIndex2 - 6);
                        }
                    }
                    else{
                        if(parentIndex1 > parentIndex2){
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex1 - 6).SetSiblingIndex(parentIndex2 - 6);
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex2 - 5).SetSiblingIndex(parentIndex1 - 6);
                        }
                        else{
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex1 - 6).SetSiblingIndex(parentIndex2 - 6);
                            allCarsOwned.transform.GetChild(1).GetChild(parentIndex2 - 7).SetSiblingIndex(parentIndex1 - 6);
                        }
                    }
                }
            }
            }
        }
    }
    }
}
