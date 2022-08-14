using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityConteiner : MonoBehaviour
{
    [SerializeField] private Transform baseParentAbility;
    [SerializeField] private Image coolDownPanel;
    [SerializeField] private Image icon;

    private Coroutine timer;
    private float timeToReady;

    public AbilityBase ability;
    public AbilitySlotQuickAccess currentSlot;

    public bool conteinerInCoolDown = false;

    private void Start()
    {
        ability = GetComponent<AbilityBase>();
    }
    public void ReturnAbilityToTree()
    {
        transform.SetParent(baseParentAbility);
        transform.localPosition = Vector3.zero;
        currentSlot = null;
    }
    public void StartTimer()
    {
        GetComponent<Drag>().enabled = false;
        currentSlot.GetComponent<DropAbility>().enabled = false;

        conteinerInCoolDown = true;
        coolDownPanel.gameObject.SetActive(true);
        coolDownPanel.fillAmount = 1;
        timeToReady = ability.coolDown;

        timer = StartCoroutine(Timer());
    }
    private IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            timeToReady--;
            coolDownPanel.fillAmount -= 1 / ability.coolDown;
            if (timeToReady == 0)
            {
                EndTimer();
            }
        }
    }
    public void EndTimer()
    {
        StopCoroutine(timer);

        conteinerInCoolDown = false;
        coolDownPanel.gameObject.SetActive(false);

        GetComponent<Drag>().enabled = true;
        currentSlot.GetComponent<DropAbility>().enabled = true;
    }
}
