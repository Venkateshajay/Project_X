using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using StarterAssets;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    public Items item;
    public Doors door;
    private InventoryManager inventory;

    private void Start()
    {
        inventory = FindObjectOfType<InventoryManager>();
    }
    public void ImmobilizePlayer()
    {
        playerInput.enabled = false;
    }

    public void MobilizePlayer()
    {
        playerInput.enabled = true;
    }

    public void OnInteract()
    {
        Debug.Log("E");
        if(item != null)
        {
            item.Interact();
        }else if(door != null)
        {
            door.Interact();
        }
    }

    public bool CheckForKeys(int id)
    {
        return inventory.CheckForKeys(id);
    }
}
