using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadableItems : MonoBehaviour, InventoryItems
{
    public bool CanUse()
    {
        return true;
    }

    public void Consume()
    {
        Debug.Log("Document's panel opened");
    }
}
