using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance
{
    public ItemsData item;
    public InventoryItems itemObject;
    public ItemInstance(ItemsData itemData)
    {
        switch (itemData.itemName)
        {
            case "key":
                Key key = new Key();
                itemObject = key;
                break;

            case "Torch Light":
                TorchLight torchLight = new TorchLight();
                itemObject = torchLight;
                break;
        }
        item = itemData;
    }

}
