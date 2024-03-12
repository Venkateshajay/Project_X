using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight :  InventoryItems
{
    public bool canUse;
    public void Consume()
    {
        Debug.Log("Torch Light used");
    }

    public bool CanUse()
    {
        return canUse;
    }
}
