using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character Stats", menuName = "BasicStats/BasicCharacterValue", order = 1)]
public class BasicCharacterDataStats : ScriptableObject
{
    public float health;
    public float speed;
}
