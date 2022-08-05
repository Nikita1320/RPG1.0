using UnityEngine;

public class AbilitySlotTree : MonoBehaviour
{
    public GameObject containerPrefab;
    public int lvlAccess;

    private void Start()
    {
        //character.levelUp += OpenAbility;
    }

    public void OpenAbility(int lvl)
    {
        if (lvlAccess == lvl)
        {
            containerPrefab.SetActive(true);
        }
    }
}
