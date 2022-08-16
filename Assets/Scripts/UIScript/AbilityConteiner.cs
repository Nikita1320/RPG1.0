using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityConteiner : MonoBehaviour
{
    [SerializeField] private Transform baseParentAbility;
    public AbilitySlotQuickAccess currentSlot;

    public void ReturnAbilityToTree()
    {
        transform.SetParent(baseParentAbility);
        transform.localPosition = Vector3.zero;
        currentSlot = null;
    }
}
