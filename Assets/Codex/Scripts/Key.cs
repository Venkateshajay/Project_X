using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : InventoryItems
{
    public bool canUse = true;
    public int useId;

    public Key(int useId)
    {
        this.useId = useId;
    }
    public void Consume()
    {
        Debug.Log("key used");
    }

    public bool CanUse()
    {
        return canUse;
    }

    public int GetUseId()
    {
        return useId;
    }
}
