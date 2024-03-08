using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface InventoryItems
{
    public bool CanUse();
    public void Consume();
}
