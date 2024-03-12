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
}
