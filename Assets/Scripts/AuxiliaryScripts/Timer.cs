using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private Coroutine coroutine;
    private int time = 5;
    private GameObject parentObject;

    public void StartTimer(GameObject gameObject, int _time)
    {
        time = _time;
        coroutine = StartCoroutine(Timer1());
    }

    IEnumerator Timer1()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (parentObject != null)
            {
                Debug.Log("Run");
                time -= 1;
                if (time <= 0)
                {
                    Debug.Log("End");
                    ExitTimer();
                }
            }
        }
    }
    public void ExitTimer()
    {
        StopCoroutine(coroutine);
    }
}
