using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDown : MonoBehaviour
{
    public delegate void EndCoolDownEvent();
    public EndCoolDownEvent endCoolDownEvent;
    [SerializeField]private Image coolDownImage;
    private float tick;
    private float coolDown;
    private float tickImageAmount;
    private Coroutine timer;
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
        float i = coolDown;
        while (true)
        {
            yield return new WaitForSeconds(1);
            i--;
            UpdateUI();
            if (i <= 0)
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
