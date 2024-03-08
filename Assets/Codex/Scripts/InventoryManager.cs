using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{   
    private InventoryItems[] items;
    private int itemIndex;

    private void Update()
    {
        if (items[itemIndex].CanUse() && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Object used");
            items[itemIndex].Consume();
        }
    }
}
