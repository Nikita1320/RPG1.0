using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 5;
    [SerializeField] private float baseJumpPower = 5;
    [SerializeField] private float baseJerkPower = 1;
    [SerializeField] private float baseArmor = 1;
    [SerializeField] private float baseDamage = 1;
    [SerializeField] private float baseMagicResistance = 1;
    [SerializeField] private float baseResistanceToEffects = 1;
    [SerializeField] private float baseCooldownReduction = 1;

    //œÓ‰Ó·‡Ú¸ ÙÓÏÛÎÛ ‰Îˇ Í‡Ê‰Ó„Ó Ò‚ÓÈÒÚ‚‡
    public float MoveSpeed { get { return (baseMoveSpeed + ValueOfChangeSpeed) * —oefficientOfChangeSpeed; } }
    public float JumpPower { get { return (baseJumpPower + ValueOfChangeJumpPower) * —oefficientOfChangeJumpPower; } }
    public float JerkPower { get { return (baseJerkPower + ValueOfChangeJerkPower) * —oefficientOfChangeJerkPower; } }
    public float Armor { get { return (baseArmor + ValueOfChangeArmor) * —oefficientOfChangeArmor; } }
    public float Damage { get { return (baseDamage + ValueOfChangeDamage) * —oefficientOfChangeDamage; }  }
    public float MagicResistance { get { return baseMagicResistance * —oefficientOfChangeMagicResistance; } }
    public float ResistanceToEffects { get { return baseResistanceToEffects * —oefficientOfChangeResistanceToEffects; } }
    public float CooldownReduction { get { return baseCooldownReduction * —oefficientOfChangeCooldownReduction; } }

    public float —oefficientOfChangeSpeed { private get { return —oefficientOfChangeSpeed; } set { —oefficientOfChangeSpeed *= value; } }
    public float —oefficientOfChangeJumpPower { private get { return —oefficientOfChangeJumpPower; } set { —oefficientOfChangeJumpPower *= value; } }
    public float —oefficientOfChangeJerkPower { private get { return —oefficientOfChangeJerkPower; } set { —oefficientOfChangeJerkPower *= value; } }
    public float —oefficientOfChangeArmor { private get { return —oefficientOfChangeArmor; } set { —oefficientOfChangeArmor *= value; } }
    public float —oefficientOfChangeDamage { private get { return —oefficientOfChangeDamage; } set { —oefficientOfChangeDamage *= value; } }
    public float —oefficientOfChangeMagicResistance { private get { return —oefficientOfChangeMagicResistance; } set { —oefficientOfChangeMagicResistance *= value; } }
    public float —oefficientOfChangeResistanceToEffects { private get { return —oefficientOfChangeResistanceToEffects; } set { —oefficientOfChangeResistanceToEffects *= value; } }
    public float —oefficientOfChangeCooldownReduction { private get { return —oefficientOfChangeCooldownReduction; } set { —oefficientOfChangeCooldownReduction *= value; } }

    public float ValueOfChangeSpeed { private get { return ValueOfChangeSpeed; } set { ValueOfChangeSpeed += value; } }
    public float ValueOfChangeJumpPower { private get { return ValueOfChangeJumpPower; } set { ValueOfChangeJumpPower += value; } }
    public float ValueOfChangeJerkPower { private get { return ValueOfChangeJerkPower; } set { ValueOfChangeJerkPower += value; } }
    public float ValueOfChangeArmor { private get { return ValueOfChangeArmor; } set { ValueOfChangeArmor += value; } }
    public float ValueOfChangeDamage { private get { return ValueOfChangeDamage; } set { ValueOfChangeDamage += value; } }

    public delegate void ChangeSpeed();
    public ChangeSpeed changeSpeed;

    public delegate void ChangeJumpPower();
    public ChangeJumpPower changeJumpPower;

    public delegate void ChangeJerkPower();
    public ChangeJerkPower changeJerkPowerr;

    public delegate void ChangeArmor();
    public ChangeArmor changeArmor;

    public delegate void ChangeDamage();
    public ChangeDamage changeDamage;

    public delegate void ChangeMagicResistance();
    public ChangeMagicResistance changeMagicResistance;

    public delegate void ChangeResistanceToEffects();
    public ChangeResistanceToEffects changeResistanceToEffects;

    public delegate void ChangeCooldownReduction();
    public ChangeCooldownReduction changeCooldownReduction;
}
