using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityConteiner : MonoBehaviour
{
    [SerializeField] private Transform baseParentAbility;
    [SerializeField] private Image icon;

    private void Start()
    {
        icon.sprite = GetComponent<AbilityBase>().Icon;
    }
    public void ReturnAbilityToTree()
    {
        transform.SetParent(baseParentAbility);
        transform.localPosition = Vector3.zero;
    }
}
