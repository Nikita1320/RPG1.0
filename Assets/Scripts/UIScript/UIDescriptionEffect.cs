using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class UIDescriptionEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject descriptionPanel;
    [SerializeField] private TMP_Text nameEffect;
    [SerializeField] private TMP_Text description;

    private EffectBase effect;
    public void Init(EffectBase _effect)
    {
        effect = _effect;
        nameEffect.text = effect.EffectData.NameEffect;
        description.text = effect.EffectData.Description;
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
