using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AbilityConteiner : MonoBehaviour
{
    [SerializeField] private Transform baseParentAbility;
    public AbilityBase ability;

    public AbilitySlotQuickAccess currentSlot;

    private void Start()
    {
        ability = GetComponent<AbilityBase>();
    }
    public void ReturnAbilityToTree()
    {
        if (ability.canBeUsed)
        {
            transform.SetParent(baseParentAbility);
            transform.localPosition = Vector3.zero;
            currentSlot = null;
        }
    }
}
