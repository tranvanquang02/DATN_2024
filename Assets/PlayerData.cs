using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/Plyer Data")]
public class PlayerData : ScriptableObject
{
    public string characterName;
    public Gender characterGender;
    public int saveSlotId;
}
