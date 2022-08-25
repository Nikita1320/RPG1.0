using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIHealth : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Health healthCharacter;
    [SerializeField] private TMP_Text text;
    private void Start()
    {
        healthCharacter.changeCurrentHealthEvent += UpdateCurrentHealthImage;
        healthCharacter.changeMaxHealthEvent += UpdateMaxHealthImage;
    }
    private void UpdateCurrentHealthImage(float currentHealth)
    {
        image.fillAmount = healthCharacter.CurrentHealth / healthCharacter.MaxHealth;
        text.text = $"{healthCharacter.CurrentHealth} / {healthCharacter.MaxHealth}";
    }

    private void UpdateMaxHealthImage(float maxHealth)
    {
        text.text = $"{healthCharacter.CurrentHealth} / {healthCharacter.MaxHealth}";
    }
}
