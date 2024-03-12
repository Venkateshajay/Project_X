using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{   
    private List<ItemInstance> items = new List<ItemInstance>();
    [SerializeField]private int itemIndex;

    /*private void Update()
    {
        if (items[itemIndex].itemObject.CanUse() && Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Object used");
            items[itemIndex].itemObject.Consume();
        }
    }*/

    public void Update()
    {
       if(Input.GetKeyDown(KeyCode.H))
       Debug.Log(items[itemIndex].item.itemName);
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            itemIndex = 0;
            UseItem();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            itemIndex = 1;
            UseItem();
        }
    }

    public bool CheckForKeys(int id)
    {
        for(int i=0;i<items.Count; i++)
        {
            if(items[i].itemObject is Key)
            {
                if(id == items[i].itemObject.GetUseId())
                {
                    Remove(i);
                    return true;
                }
            }
        }
        return false;
    }

    public void UseItem()
    {
        if (items[itemIndex].itemObject.CanUse())
        {
            Debug.Log("Object used");
            items[itemIndex].itemObject.Consume();
        }
    }

    public void Add(ItemsData itemInstance)
    {
        items.Add(new ItemInstance(itemInstance));
    }

    private void Remove(int index)
    {
        items.RemoveAt(index);
    }
}
