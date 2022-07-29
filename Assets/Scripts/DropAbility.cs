using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropAbility : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var receivedContainer = eventData.pointerDrag.transform;
        receivedContainer.SetParent(transform);
        receivedContainer.localPosition = Vector3.zero;
    }
}
