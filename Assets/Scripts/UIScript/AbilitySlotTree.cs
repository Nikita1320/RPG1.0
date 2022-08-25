using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilitySlotTree : MonoBehaviour
{
    public GameObject containerPrefab;
    public int lvlAccess;
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text text;
    private bool isOpen;

    private void Start()
    {
        //icon.sprite = containerPrefab.GetComponent<AbilityBase>().Icon.sprite;
        //text.text = $"{lvlAccess} lvl";
        //character.levelUp += OpenAbility;
    }

    public void OpenAbility(int lvl)
    {
        if (lvlAccess == lvl)
        {
            containerPrefab.SetActive(true);
            isOpen = true;
            text.gameObject.SetActive(false);
        }
    }
}
