using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIDescriptionItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private TMP_Text nameItem;
    [SerializeField] private TMP_Text description;

    private ItemBase item;

    private void Start()
    {
        item = GetComponent<ItemBase>();
        nameItem.text = item.name;
        description.text = item.description;
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
