using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ArmType
{
    Axe,
    Revolver,
}

public class WeaponUseType : MonoBehaviour
{
    public ArmType ArmType;
}
