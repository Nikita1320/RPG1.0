using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EffectConteiner : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image coolDownImage;

    public void Init(EffectBase effect)
    {
        icon.sprite = effect.EffectData.Icon;
        effect.tickEvent += UpdateUI;
        effect.endEffectEvent += EndEffect;
    }
    public void UpdateUI(float valueFillAmount)
    {
        coolDownImage.fillAmount = valueFillAmount;
    }
    private void EndEffect()
    {
        Destroy(gameObject);
    }
}
