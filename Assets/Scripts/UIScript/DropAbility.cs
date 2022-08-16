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
            if (abilityConteiner.currentSlot.TryGetComponent(out AbilitySlotQuickAccess dragSlot)) //����������� �� ������ ��� �� ����� �������?
            {
                if (dropAbilitySlot.AbilityConteinerInSlot == null) //���� ����?
                {
                    dropAbilitySlot.AddAbility(abilityConteiner);
                    MoveToSlot(abilityConteiner.transform, transform);
                    dragSlot.ClearSlot(false);
                }
                else
                {
                    AbilityConteiner temp = dropAbilitySlot.AbilityConteinerInSlot;

                    MoveToSlot(abilityConteiner.transform, transform);
                    dropAbilitySlot.AddAbility(abilityConteiner);

                    dragSlot.AddAbility(temp);
                    MoveToSlot(temp.transform, dragSlot.transform);
                }
            }
            else
            {
                if (dropAbilitySlot.AbilityConteinerInSlot == null) //���� ����?
                {
                    dropAbilitySlot.AddAbility(abilityConteiner);
                    MoveToSlot(abilityConteiner.transform, transform);
                }
                else
                {
                    dropAbilitySlot.ClearSlot(true);
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
        dragObject.SetAsFirstSibling();
    }
}
