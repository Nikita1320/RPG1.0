using UnityEngine;
using UnityEngine.UI;

public class TimerEffect : MonoBehaviour
{
    [SerializeField] private Image coolDownImage;
    public void Init(EffectBase effect)
    {
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
