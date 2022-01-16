using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public bool isEnable;
    public bool isActive;
    public int statusId { get; set; } = 1;
}
