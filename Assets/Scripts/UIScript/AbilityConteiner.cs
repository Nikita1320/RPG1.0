using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityConteiner : MonoBehaviour
{
    [SerializeField] private Transform baseParentAbility;
    [SerializeField] private Image icon;
    [SerializeField] private Image coolDownImage;

    private void Start()
    {
        AbilityBase ability = GetComponent<AbilityBase>();
        icon.sprite = ability.Icon;
        if (ability.TryGetComponent(out ActiveAbilityBase activeAbility))
        {
            activeAbility.startCoolDownTimerEvent += StartTimer;
            activeAbility.tickCoolDownTimerEvent += UpdateUI;
            activeAbility.endCoolDownTimerEvent += EndTimer;
        }
    }
    public void ReturnAbilityToTree()
    {
        transform.SetParent(baseParentAbility);
        transform.localPosition = Vector3.zero;
    }
    public void StartTimer()
    {
        coolDownImage.gameObject.SetActive(true);
        coolDownImage.fillAmount = 1;
        Debug.Log("StartCoolDown");
    }
    public void UpdateUI(float amountValue)
    {
        coolDownImage.fillAmount -= amountValue;
        Debug.Log("TickCoolDown");
    }
    public void EndTimer()
    {
        coolDownImage.gameObject.SetActive(false);
        Debug.Log("EndCoolDown");
    }
}
