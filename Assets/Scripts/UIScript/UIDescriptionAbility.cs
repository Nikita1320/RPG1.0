using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class UIDescriptionAbility : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private TMP_Text nameAbility;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text type;

    private AbilityBase ability;
    private void Start()
    {
        ability = GetComponent<AbilityBase>();
        nameAbility.text = ability.NameAbility;
        description.text = ability.Description;
        type.text = ability.TypeAbility.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        descriptionPanel.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        descriptionPanel.SetActive(false);
    }
}
