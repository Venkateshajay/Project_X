using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemsData : ScriptableObject
{
    public int useId;
    public string itemName;
    public Sprite icon;
    [TextArea]
    public string description;
}
