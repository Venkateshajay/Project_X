using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key :MonoBehaviour, InventoryItems
{
    public bool canUse;
    public void Consume()
    {
        Debug.Log("key used");
    }

    public bool CanUse()
    {
        return canUse;
    }
}
