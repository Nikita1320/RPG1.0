using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    [SerializeField]private Image coolDownImage;
    private float coolDown;
    private float tickImageAmount;
    private Coroutine timer;

    public delegate void EndCoolDownEvent();
    public EndCoolDownEvent endCoolDownEvent;
    
    public bool TimerIsRun { get; private set; }
    public void StartTimer(float _coolDown)
    {
        coolDown = _coolDown;
        tickImageAmount = 1 / coolDown;
        TimerIsRun = true;
        coolDownImage.fillAmount = 1;
        timer = StartCoroutine(Timer());
    }
    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            coolDown--;
            UpdateUI();
            if (coolDown <= 0)
            {
                EndTimer();
            }
        }
    }

    public void EndTimer()
    {
        StopCoroutine(timer);
        TimerIsRun = false;
        coolDownImage.fillAmount = 0;
        endCoolDownEvent();
    }

    private void UpdateUI()
    {
        coolDownImage.fillAmount -= tickImageAmount;
    }
}
