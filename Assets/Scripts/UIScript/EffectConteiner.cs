using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectConteiner : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image coolDownImage;
    public Image CoolDownImage => coolDownImage;

    public void Init(Sprite spriteIcon)
    {
        icon.sprite = spriteIcon;
        Debug.Log(spriteIcon.name);
    }
}
