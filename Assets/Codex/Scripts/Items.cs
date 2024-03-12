using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour , Interactables
{
    [SerializeField] ItemsData itemData;
    [SerializeField] InventoryManager inventory;

    void Start()
    {
        inventory = FindObjectOfType<InventoryManager>().GetComponent<InventoryManager>();
    }
    public enum ItemState
    {
        Pickable,
        NonPickable
    }
    [SerializeField] ItemState itemState;
    private bool canInteract = true;

    public bool CanInteract()
    {
        return canInteract;
    }

    public void Interact()
    {
        if(itemState == ItemState.Pickable)
        {
            Pick();
        }
        else
        {
            See();
        }
        Debug.Log("Interaction successfull");
    }

    private void Pick()
    {
        ItemInstance itemInstance = new ItemInstance(itemData);
        if (inventory == null)
        {
            Debug.Log("inventory is null");
            return;
        }else if(itemInstance == null)
        {
            Debug.Log("Instance is null");
            return;
        }
        inventory.Add(itemData);
        Debug.Log("Item added to inventory");
        Destroy(gameObject);
    }

    private void See()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && canInteract)
        {
            other.GetComponent<PlayerController>().item = this;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            if(other.GetComponent<PlayerController>().item == this)
            {
                other.GetComponent<PlayerController>().item = null;
            }
            
        }
    }
}
