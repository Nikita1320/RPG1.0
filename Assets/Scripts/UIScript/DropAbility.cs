using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropAbility : MonoBehaviour, IDropHandler
{
    private AbilitySlotQuickAccess dropAbilitySlot;
    private void Start()
    {
        dropAbilitySlot = GetComponent<AbilitySlotQuickAccess>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag.TryGetComponent(out AbilityConteiner abilityConteiner)) //������ � ����������� drag - �����������?
        {
            if (abilityConteiner.currentSlot != null) //����������� �� ������ ��� �� ����� �������?
            {
                if (dropAbilitySlot.abilityConteiner == null) //���� ����?
                {
                    AbilitySlotQuickAccess dragSlot = abilityConteiner.currentSlot;

                    dropAbilitySlot.AddAbility(abilityConteiner);
                    MoveToSlot(abilityConteiner.transform, transform);
                    dragSlot.abilityConteiner = null;
                }
                else
                {
                    AbilityConteiner temp = dropAbilitySlot.abilityConteiner;
                    AbilitySlotQuickAccess dragSlot = abilityConteiner.currentSlot;

                    MoveToSlot(abilityConteiner.transform, transform);
                    dropAbilitySlot.AddAbility(abilityConteiner);

                    dragSlot.AddAbility(temp);
                    MoveToSlot(temp.transform, dragSlot.transform);
                }
            }
            else
            {
                if (dropAbilitySlot.abilityConteiner == null) //���� ����?
                {
                    dropAbilitySlot.AddAbility(abilityConteiner);
                    MoveToSlot(abilityConteiner.transform, transform);
                }
                else
                {
                    dropAbilitySlot.ClearSlot();
                    dropAbilitySlot.AddAbility(abilityConteiner);
                    MoveToSlot(abilityConteiner.transform, transform);
                }
            }
        }
    }
    public void MoveToSlot(Transform dragObject, Transform dropObject)
    {
        dragObject.SetParent(dropObject);
        dragObject.localPosition = Vector3.zero;
    }
}
